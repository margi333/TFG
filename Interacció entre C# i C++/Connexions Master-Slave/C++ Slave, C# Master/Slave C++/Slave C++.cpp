#include <iostream>       // Biblioteca per a operacions d'entrada/sortida per consola
#include "Header.h"       // Arxiu d'encapçalament on es declaren variables globals i constants

// Funció que envia el codi de confirmació ACK (0x06) al client
int server_sendACK(SOCKET clientSck)
{
    int nBytes;
    char buf = 0x06;  // ACK (Acknowledge), codi ASCII per confirmar recepció

    nBytes = send(clientSck, &buf, 1, 0);  // Envia 1 byte al client
    if (nBytes == SOCKET_ERROR)
    {
        printf("send ACK failed with error: %d\n", WSAGetLastError());
        return 1;  // Retorna error
    }
    return 0; // Enviament correcte
}

// Funció que obre i configura el servidor en el port indicat
bool server_open(char* port)
{
    WSADATA wsaData;
    int iResult;

    // Inicialització de sockets com a invàlids
    g_listenSocket = INVALID_SOCKET;
    g_clientSocket = INVALID_SOCKET;
    g_result = NULL;

    struct addrinfo hints;

    // Inicialitza la llibreria WinSock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed with error: %d\n", iResult);
        return true;
    }

    // Configura la informació de la connexió
    ZeroMemory(&hints, sizeof(hints)); // Neteja la memòria de la estructura hints
    hints.ai_family = AF_INET;         // IPv4
    hints.ai_socktype = SOCK_STREAM;   // Tipus TCP
    hints.ai_protocol = IPPROTO_TCP;   // Protocol TCP
    hints.ai_flags = AI_PASSIVE;       // Accepta connexions entrants

    // Resol la IP i el port del servidor
    iResult = getaddrinfo("192.168.68.105", port, &hints, &g_result);
    if (iResult != 0)
    {
        printf("getaddrinfo failed with error: %d\n", iResult);
        return true;
    }

    // Crea el socket d'escolta per connexions entrants
    g_listenSocket = socket(g_result->ai_family, g_result->ai_socktype, g_result->ai_protocol);
    if (g_listenSocket == INVALID_SOCKET)
    {
        printf("socket failed with error: %ld\n", WSAGetLastError());
        return true;
    }

    // Associa el socket amb l'adreça IP i el port
    iResult = bind(g_listenSocket, g_result->ai_addr, (int)g_result->ai_addrlen);
    if (iResult == SOCKET_ERROR)
    {
        printf("bind failed with error: %d\n", WSAGetLastError());
        return true;
    }

    g_result = NULL;

    // Posa el socket en mode escolta per a connexions entrants
    iResult = listen(g_listenSocket, SOMAXCONN);
    if (iResult == SOCKET_ERROR)
    {
        printf("listen failed with error: %d\n", WSAGetLastError());
        return true;
    }

    return 0; // Tot correcte
}

// Funció que tanca el servidor i allibera recursos
void server_close()
{
    if (g_result != NULL)
        freeaddrinfo(g_result);           // Allibera la memòria d'adreces
    if (g_clientSocket != INVALID_SOCKET)
        closesocket(g_clientSocket);     // Tanca el socket del client
    if (g_listenSocket != INVALID_SOCKET)
        closesocket(g_listenSocket);     // Tanca el socket del servidor

    WSACleanup();                        // Finalitza l'ús de la llibreria WinSock
}

// Funció per rebre un paquet del client i enviar ACK si s’ha rebut correctament
// El buffer conté les dades rebudes i len retorna la seva mida
int server_recvPack(SOCKET clientSck, char* buffer, int* len)
{
    int recvBufLen = DEFAULT_BUFLEN;  // Longitud màxima del buffer
    int nBytes;

    // Rep les dades del client
    nBytes = recv(clientSck, buffer, recvBufLen, 0);
    if (nBytes > 0)
    {
        // Si la recepció és correcta, envia ACK i guarda la mida rebuda
        if (server_sendACK(clientSck) == 0)
        {
            *len = nBytes;
            return 0;
        }
        else return 1;
    }
    else if (nBytes == 0) {
        printf("Warning: no information received\n");  // Connexió oberta però sense dades
    }
    else
    {
        printf("recv failed with error: %d\n", WSAGetLastError());
        return 1;
    }
    return 0;
}

// Funció principal que espera una connexió de client i processa les ordres rebudes
bool server_attnSocket()
{
    int iResult, ret;

    // Accepta una connexió entrant
    g_clientSocket = accept(g_listenSocket, NULL, NULL);
    if (g_clientSocket == INVALID_SOCKET)
    {
        printf("accept failed with error: %d\n", WSAGetLastError());
        return true;
    }

    // Bucle principal per processar ordres contínuament
    while (true)
    {
        int recvBufLen;
        char buffer[3]; // El paquet conté 3 bytes: num1, num2, operació

        // Espera a rebre una ordre del client
        if (server_recvPack(g_clientSocket, buffer, &recvBufLen) != 0)
            return true;

        // Extracció dels valors del buffer
        int num1 = buffer[0];
        int num2 = buffer[1];
        int operacio = buffer[2];

        // Processament segons el codi d’operació
        switch (operacio)
        {
        case 1: // Suma
            printf("Els numeros rebuts son: %d, %d. La suma equival a %d\n", num1, num2, num1 + num2);
            break;
        case 2: // Resta
            printf("Els numeros rebuts son: %d, %d. La resta equival a %d\n", num1, num2, num1 - num2);
            break;
        default: // Operació no reconeguda
            printf("Operació desconeguda: %d\n", operacio);
            break;
        }
    }
}

// Punt d'entrada principal del programa
int main()
{
    printf("Server: hello world!\n\n");
    int resposta = 0;

    // Inicialitza el servidor en el port 27643
    if (server_open((char*)"27643") == true)
    {
        printf("Error: server in not ready\n");
        return 1;
    }

    // Entra en mode d'atenció de connexions (bucle bloquejant)
    if (server_attnSocket())
    {
        server_close();  // Tanca el servidor si hi ha error o es finalitza
        return 0;
    }
}

