// Arxiu principal del programa (TFG - aplicació de consola)
// Conté la funció main() que és el punt d’entrada del programa

#include <iostream>     // Entrada/sortida per consola
#include "encabezado.h" // Inclou la definició de la classe 'operacio'
#include <conio.h>      // Per funcions de lectura de teclat sense enter (_getch(), _kbhit())
#include <windows.h>    // Funcions del sistema per Windows

#define uchar unsigned char // Alias per uchar (unsigned char)
#define uint unsigned int   // Alias per uint (unsigned int)

int main()
{
    bool end = false;         // Control per acabar el programa
    bool trama_ok = false;    // Control per saber si l’entrada s’ha completat
    uchar cadena[10];         // Array per emmagatzemar els caràcters escrits per l’usuari
    int i = 0;                // Índex de la cadena
    operacio Obj;             // Objecte per fer la conversió de divises

    while (!end)
    {
        printf("Escriu import de la divisa que vulguis cambiar:\n\r");

        // --- LECTURA DE CARÀCTERS UN A UN ---
        do
        {
            if (_kbhit()) // Si s’ha premut una tecla...
            {
                uchar a = _getch(); // ... es captura sense necessitat de prémer ENTER

                switch (a)
                {
                case 27: // Tecla ESC → sortir del programa
                    end = true;
                    trama_ok = true;
                    break;

                case 13: // Tecla ENTER → finalitzar entrada de dades
                    trama_ok = true;
                    printf("\n\r");
                    break;

                default:
                    // Emmagatzema el caràcter a l’array i el mostra per consola
                    cadena[i] = a;
                    printf("%c", a);
                    i++;
                    break;
                }
            }
        } while (!trama_ok);

        // Si l’usuari ha premut ESC, es finalitza el programa
        if (end)
        {
            printf("Aplicació finalitzada\n\r");
            return 0;
        }

        // --- VALIDACIÓ I CONVERSIÓ DE LA CADENA ---
        char* end;
        trama_ok = false;

        // Converteix la cadena introduïda a float (fins a la primera lletra)
        float valor = strtof((const char*)cadena, &end);

        // Si la conversió ha fallat o el valor és negatiu
        if (*end == '\0' || valor < 0)
        {
            printf("Import introduït no vàlid\n\r");
        }
        else
        {
            // --- IDENTIFICACIÓ DE LA DIVISA ---
            if (cadena[i - 1] == 'e')
            {
                // Si l'últim caràcter és 'e', es converteix d’euros a dòlars
                printf("El valor introduït és %.2f e --> %.2f d\n\r\n\r", valor, Obj.EuroToDollar(valor));
            }
            else if (cadena[i - 1] == 'd')
            {
                // Si l'últim caràcter és 'd', es converteix de dòlars a euros
                printf("El valor introduït és %.2f d --> %.2f e\n\r\n\r", valor, Obj.DollarToEuro(valor));
            }
            else
            {
                // Si la divisa no és reconeguda
                printf("No s'ha detectat la divisa o no suportem aquesta divisa encara\n\r\n\r");
            }
        }

        // Neteja l’array de caràcters per la següent entrada
        for (int j = 0; j < i; j++)
        {
            cadena[j] = '\0';
        }

        i = 0; // Reinicia l’índex
    }

    return 0; // Finalització correcta del programa
}
