// Aplicació simple de consola en C++
// La funció main és el punt d'entrada i de sortida del programa
#include <windows.h>   // Llibreria de funcions de Windows
#include <stdio.h>     // Funcions d’entrada/sortida estàndard
#include <conio.h>     // Per usar _getch() i _kbhit() per lectura de teclat sense enter
#include "Header.h";   // Arxiu d'encapçalament on es declara la funció 'suma'

// Funció principal
int main()
{
    // Bucle infinit per repetir l’operació contínuament
    while (true)
    {
        printf("Introdueix un número del 0 al 9\n\r");

        bool num_valid = false;
        char num1, num2;
        const char* apunt_n1 = &num1;
        const char* apunt_n2 = &num2;
        int n1, n2;

        // --- Lectura del primer número ---
        while (!num_valid)
        {
            if (_kbhit())  // Comprova si s’ha premut una tecla
            {
                char a = _getch();  // Llegeix el caràcter sense mostrar-lo
                if (a < 48 || a > 57)  // ASCII de '0' a '9'
                {
                    printf("Introdueix un número dins del rang\n\r");
                }
                else
                {
                    num1 = a;
                    num_valid = true;
                }
            }
        }

        // Conversió de caràcter ASCII a enter
        n1 = atoi(apunt_n1);

        // --- Lectura del segon número ---
        num_valid = false;
        printf("Introdueix un segon número del 0 al 9\n\r");
        while (!num_valid)
        {
            if (_kbhit())
            {
                char a = _getch();
                if (a < 48 || a > 57)
                {
                    printf("Introdueix un número dins del rang\n\r");
                }
                else
                {
                    num2 = a;
                    num_valid = true;
                }
            }
        }

        // Conversió del segon número
        n2 = atoi(apunt_n2);

        // Crida a la funció suma() declarada a Header.h
        printf("El resultat de la suma és %d\n\r\n\r", suma(n1, n2));
    }
}
