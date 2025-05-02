// Necessari per a sockets a Windows
#define WIN32_LEAN_AND_MEAN  // Evita conflictes amb Windows.h
#include <windows.h>         // Llibreria bàsica de Windows
#include <winsock2.h>        // Llibreria per a sockets
#include <ws2tcpip.h>        // Suport per a IPv6 i adreces IP
#include <iphlpapi.h>        // Suport per a networking addicional
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>           // Per _getch() i _kbhit()

#pragma comment(lib, "Ws2_32.lib") // Enllaça automàticament la llibreria Winsock

static SOCKET g_connectSocket; /*Socket de conexión*/
static struct addrinfo* g_sResult;

#define ACK 0x06
#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT 27643


bool client_open(char* servername, char* port);
void client_close(void);
int client_serverConnect(void);
int client_sendPack(SOCKET clientSck, char* buffer, int len);