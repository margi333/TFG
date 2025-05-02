#include <iostream>
#include "Header.h"

//Envia el código de confirmación
int server_sendACK(SOCKET clientSck)
{
    int nBytes;
    char buf = 0x06;

    nBytes = send(clientSck, &buf, 1, 0);
    if (nBytes == SOCKET_ERROR)
    {
        printf("send ACK failed with error: %d\n", WSAGetLastError());
        return 1;
    }
    return 0;
}


bool server_open(char* port)
{

    WSADATA wsaData;
    int iResult;

    g_listenSocket = INVALID_SOCKET;
    g_clientSocket = INVALID_SOCKET;

    g_result = NULL;
    struct addrinfo hints;

    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed with error: %d\n", iResult);
        return true;
    }

    ZeroMemory(&hints, sizeof(hints)); // Condicions inicials a 0
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;
    hints.ai_flags = AI_PASSIVE;

    // Resolve the server address and port
    iResult = getaddrinfo("192.168.68.105", port, &hints, &g_result);
    if (iResult != 0)
    {
        printf("getaddrinfo failed with error: %d\n", iResult);
        return true;
    }

    // Create a SOCKET for connecting to client
    g_listenSocket = socket(g_result->ai_family, g_result->ai_socktype, g_result->ai_protocol);
    if (g_listenSocket == INVALID_SOCKET)
    {
        printf("socket failed with error: %ld\n", WSAGetLastError());
        return true;
    }

    // Setup the TCP listening socket
    // associates a local address with a socket.
    iResult = bind(g_listenSocket, g_result->ai_addr, (int)g_result->ai_addrlen);
    if (iResult == SOCKET_ERROR)
    {
        printf("bind failed with error: %d\n", WSAGetLastError());
        return true;
    }

    g_result = NULL;

    // places a socket in a state in which it is listening for an incoming connection.
    iResult = listen(g_listenSocket, SOMAXCONN);
    if (iResult == SOCKET_ERROR)
    {
        printf("listen failed with error: %d\n", WSAGetLastError());
        return true;
    }
    return 0;
}

//Se cierra el servidor
void server_close()
{
    if (g_result != NULL)
        freeaddrinfo(g_result);
    if (g_clientSocket != INVALID_SOCKET)
        closesocket(g_clientSocket);
    // No longer need server socket
    if (g_listenSocket != INVALID_SOCKET)
        closesocket(g_listenSocket);
    // cleanup
    WSACleanup();
}

//Recibe un paquete de información y retorna ACK si es correcto
//En buffer queda el paquete recibido cuyo tamaño se situa en len
//Retorna 1 si error
int server_recvPack(SOCKET clientSck, char* buffer, int* len)
{
    int recvBufLen = DEFAULT_BUFLEN;
    int nBytes;
    nBytes = recv(clientSck, buffer, recvBufLen, 0);
    if (nBytes > 0)
    {
        if (server_sendACK(clientSck) == 0)
        {
            *len = nBytes;
            return 0;
        }
        else return 1;
    }
    else if (nBytes == 0) {
        printf("Warning: no information received\n");
    }
    else
    {
        printf("recv failed with error: %d\n", WSAGetLastError());
        return 1;
    }
    return 0;
}


//Se está a la espera de que se conecte un cliente. 
//Luego de la conexión se entra en un bucle:
// 1) se espera a la recepción una orden
// 2) Se evalua y ejecuta la orden
//Retorna true si error o se debe cerrar el servidor
bool server_attnSocket()
{
    int iResult, ret;

    // Accept a client socket
    g_clientSocket = accept(g_listenSocket, NULL, NULL);
    if (g_clientSocket == INVALID_SOCKET)
    {
        printf("accept failed with error: %d\n", WSAGetLastError());
        return true;
    }

    while (true)
    {
        int recvBufLen;
        char buffer[3];
        //server waiting for order
        if (server_recvPack(g_clientSocket, buffer, &recvBufLen) != 0)
            return true;
        int num1 = buffer[0];
        int num2 = buffer[1];
        int operacio = buffer[2];
        switch (operacio)
        {
        case 1:
            printf("Els numeros rebuts son: %d, %d. La suma equival a %d", num1, num2, num1 + num2);
            break;
        case 2:
            printf("Els numeros rebuts son: %d, %d. La resta equival a %d", num1, num2, num1 - num2);
            break;
        }
    }
}


int main()
{
    printf("Server: hello world!\n\n");
    int resposta = 0;

    //Se activa el servidor
    if (server_open((char*)"27643") == true)
    {
        printf("Error: server in not ready\n");
        return 1;
    }
    if (server_attnSocket())//blocking
    {
        server_close();
        return 0;
    }
}

