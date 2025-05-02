#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif

#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdio.h>

// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT 27015

static SOCKET g_listenSocket;
static SOCKET g_clientSocket;
static struct addrinfo* g_result;

int server_recvPack(SOCKET clientSck, char* buffer, int* len);
bool server_open(char* port);
void server_close(void);
bool server_attnSocket(void);
bool server_attnSocket(void);
int server_sendACK(SOCKET clientSck);

#define  _WINSOCK_DEPRECATED_NO_WARNINGS 
