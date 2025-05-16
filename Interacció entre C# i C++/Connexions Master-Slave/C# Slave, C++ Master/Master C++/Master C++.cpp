#include <iostream>        // Entrada/sortida per consola
#include <conio.h>         // Per llegir tecles amb _getch() i _kbhit()
#include "Master C++.h"    // Arxiu d'encapçalament amb variables globals i definicions

// Obre la connexió amb el servidor especificat
bool client_open(char* serverName, char* port)
{
    g_connectSocket = INVALID_SOCKET;   // Inicialització del socket com a invàlid
    g_sResult = NULL;

    WSADATA wsaData;
    struct addrinfo* ptr = NULL, hints;
    int iResult;

    // Inicialitza la llibreria WinSock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed with error: %d\n", iResult);
        return true;
    }

    // Especificació de criteris per trobar adreces del servidor
    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;   // Connexió TCP
    hints.ai_protocol = IPPROTO_TCP;

    // Resolució d'adreça i port del servidor
    iResult = getaddrinfo(serverName, port, &hints, &g_sResult);
    if (iResult != 0)
    {
        printf("getaddrinfo failed with error: %d\n", iResult);
        return true;
    }

    return false;
}

// Tanca correctament la connexió i allibera recursos
void client_close(void)
{
    if (g_connectSocket)
        closesocket(g_connectSocket);
    g_connectSocket = NULL;

    if (g_sResult)
        freeaddrinfo(g_sResult);
    g_sResult = NULL;

    WSACleanup();  // Finalitza l’ús de WinSock
}

// Intenta establir connexió amb el servidor
int client_serverConnect()
{
    int iResult;
    struct addrinfo* ptr = NULL;

    // Recorre totes les adreces resoltes intentant connectar-se
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

        break;  // Connexió establerta correctament
    }

    if (g_connectSocket == INVALID_SOCKET)
    {
        printf("No s'ha pogut establir connexió amb cap adreça!\n");
        return 1;
    }

    printf("Client connectat correctament amb el servidor.\n");
    return 0;
}

// Envia una trama de dades al servidor i espera una resposta ACK
int client_sendPack(SOCKET clientSck, char* buffer, int len)
{
    int nBytes;
    char recvBuf[DEFAULT_BUFLEN];
    int recvBufLen = DEFAULT_BUFLEN;

    // Envia la trama
    nBytes = send(clientSck, buffer, len, 0);
    if (nBytes == SOCKET_ERROR)
    {
        printf("send failed with error: %d\n", WSAGetLastError());
        return 1;
    }

    // Espera una resposta del servidor
    nBytes = recv(clientSck, recvBuf, recvBufLen, 0);
    if (nBytes > 0)
    {
        // Comprova si s’ha rebut l’ACK (0x06)
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

    // Obre connexió amb el servidor (IP i port específics)
    if (client_open((char*)"192.168.68.105", (char*)"27643") == true)
        return 1;

    // Estableix connexió amb el servidor
    if (client_serverConnect() != 0)
        return 1;

    // Bucle principal per enviar operacions
    while (true)
    {
        printf("Introdueix un numero del 0 al 9\n\r");
        bool num_valid = false;
        char num1, num2, num3;
        const char* apunt_n1 = &num1;
        const char* apunt_n2 = &num2;
        const char* apunt_n3 = &num3;
        int n1, n2, n3;

        // --- Entrada del primer número ---
        while (!num_valid)
        {
            if (_kbhit()) // Comprova si s’ha premut una tecla
            {
                char a = _getch(); // Llegeix una tecla sense esperar Enter
                if ((a < 48 || a > 57) && a != 13)
                {
                    printf("Introdueix un número dins del rang\n\r");
                }
                else if (a == 13) // Tecla Enter per sortir
                {
                    printf("Tancant connexió...");
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

        // --- Entrada del segon número ---
        num_valid = false;
        printf("Introdueix un segon número del 0 al 9\n\r");
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if ((a < 48 || a > 57) && a != 13)
                {
                    printf("Introdueix un número dins del rang\n\r");
                }
                else if (a == 13)
                {
                    printf("Tancant connexió...");
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

        // --- Selecció d'operació ---
        num_valid = false;
        printf("Vol fer una suma (1) o una resta(2)\n\r");
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if ((a < 49 || a > 50) && a != 13) // Només 1 o 2
                {
                    printf("Introdueix un número dins del rang\n\r");
                }
                else if (a == 13)
                {
                    printf("Tancant connexió...");
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

        // --- Construcció de la trama a enviar ---
        int trama[3];
        int i = 0;
        trama[i++] = n1;
        trama[i++] = n2;
        trama[i++] = n3;

        // Enviament de la trama al servidor
        bool trama_ok = client_sendPack(g_connectSocket, (char*)trama, sizeof(trama));
        i = 0;

        // Resultat de l’enviament
        if (trama_ok == TRUE) {
            printf("Error: No s'ha pogut enviar l'ordre al servidor\n");
        }
        else if (trama_ok == FALSE) {
            printf("Ordre enviada correctament\n\r\n\r");
        }
    }

    client_close(); // Tanca connexió (en cas que es surti del bucle)
    return 0;
}
