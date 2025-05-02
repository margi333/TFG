#include <iostream>
#include <conio.h>
#include "Master C++.h"

bool client_open(char* serverName, char* port)
{
    g_connectSocket = INVALID_SOCKET;
    g_sResult = NULL;

    WSADATA wsaData;
    struct addrinfo* ptr = NULL, hints;
    int iResult;

    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed with error: %d\n", iResult);
        return true;
    }

    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;

    // Resolve the server address and port
    iResult = getaddrinfo(serverName, port, &hints, &g_sResult);
    if (iResult != 0)
    {
        printf("getaddrinfo failed with error: %d\n", iResult);
        return true;
    }
    return false;
}

void client_close(void)
{
    if (g_connectSocket)
        closesocket(g_connectSocket);
    g_connectSocket = NULL;
    if (g_sResult)
        freeaddrinfo(g_sResult);
    g_sResult = NULL;
    WSACleanup();
}


int client_serverConnect()
{
    int iResult;
    struct addrinfo* ptr = NULL;

    // Intenta connectar-se a una de les adreces disponibles
    for (ptr = g_sResult; ptr != NULL; ptr = ptr->ai_next)
    {
        g_connectSocket = socket(ptr->ai_family, ptr->ai_socktype, ptr->ai_protocol);
        if (g_connectSocket == INVALID_SOCKET)
        {
            printf("Error en crear el socket: %ld\n", WSAGetLastError());
            continue;
        }

        // Intenta connectar-se al servidor
    
        iResult = connect(g_connectSocket, ptr->ai_addr, (int)ptr->ai_addrlen);
        if (iResult == SOCKET_ERROR)
        {
            printf("Error en connect(): %d\n", WSAGetLastError());
            closesocket(g_connectSocket);
            g_connectSocket = INVALID_SOCKET;
            continue;
        }

        break; // Si la connexió té èxit, surt del bucle
    }

    if (g_connectSocket == INVALID_SOCKET)
    {
        printf("No s'ha pogut establir connexió amb cap adreça!\n");
        return 1;
    }

    printf("Client connectat correctament amb el servidor.\n");
    return 0;
}


int client_sendPack(SOCKET clientSck, char* buffer, int len)
{
    int nBytes;
    char recvBuf[DEFAULT_BUFLEN];
    int recvBufLen = DEFAULT_BUFLEN;

    nBytes = send(clientSck, buffer, len, 0);
    if (nBytes == SOCKET_ERROR)
    {
        printf("send failed with error: %d\n", WSAGetLastError());
        return 1;
    }
    //    printf("Bytes sent: %d\n", nBytes);
    nBytes = recv(clientSck, recvBuf, recvBufLen, 0);
    if (nBytes > 0)
    {
        if (!(nBytes == 1 && *recvBuf == ACK))
        {
            printf("ACK not received\n");
            return 1;
        }
    }
    return 0;
}



int main()
{
    char buffer[DEFAULT_BUFLEN];
    int len;
    printf("Client: Hello World!\n");
    //Se intenta establecer comunicación con el servidor que se
    //situa en la misma máquina del cliente, en el port 27643
    if (client_open((char*)"192.168.68.105", (char*)"27643") == true)
        return 1;
    //Se estblece una conexión con el servidor
    if (client_serverConnect() != 0)
        return 1;


    while (true)
    {
        printf("Introdueix un numero del 0 al 9\n\r");
        bool num_valid = false;
        char num1, num2, num3;
        const char* apunt_n1 = &num1;
        const char* apunt_n2 = &num2;
        const char* apunt_n3 = &num3;
        int n1, n2, n3;
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if ((a < 48 || a > 57) && a != 13)
                {
                    printf("Introdueix un numero dins del rang\n\r");
                }
                else if (a == 13)
                {
                    printf("Tancant connexio...");
                    client_close();
                    return 0;
                }
                else
                {
                    num1 = a;
                    num_valid = true;
                }
            }
        }
        n1 = atoi(apunt_n1);

        num_valid = false;
        printf("Introdueix un segon numero del 0 al 9\n\r");
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if ((a < 48 || a > 57) && a != 13)
                {
                    printf("Introdueix un numero dins del rang\n\r");
                }
                else if (a == 13)
                {
                    printf("Tancant connexio...");
                    client_close();
                    return 0;
                }
                else
                {
                    num2 = a;
                    num_valid = true;
                }
            }
        }
        n2 = atoi(apunt_n2);

        num_valid = false;
        printf("Vol fer una suma (1) o una resta(2)\n\r");
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if ((a < 49 || a > 50) && a != 13)
                {
                    printf("Introdueix un numero dins del rang\n\r");
                }
                else if (a == 13)
                {
                    printf("Tancant connexio...");
                    client_close();
                    return 0;
                }
                else
                {
                    num3 = a;
                    num_valid = true;
                }
            }
        }
        n3 = atoi(apunt_n3);
        //Tenim els números preparats. Ara prepararem la trama a enviar al slave
        int trama[3];
        int i = 0;
        trama[i] = n1;
        i++;
        trama[i] = n2;
        i++;
        trama[i] = n3;
        i++;
        bool trama_ok = client_sendPack(g_connectSocket, (char *)trama, sizeof(trama));
        i = 0;
        if (trama_ok == TRUE) {
            //ERROR DE RECEPCIÓN
            printf("Error: No s'ha pogut enviar l'ordre al servidor\n");
        }
        else if (trama_ok == FALSE) {
            //ENVIO CORRECTE
            printf("Ordre enviada correctament\n\r\n\r");
        }
    }
    client_close();
    return 0;
}

