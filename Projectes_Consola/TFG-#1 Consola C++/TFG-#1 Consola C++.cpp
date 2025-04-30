// TFG-#1 Consola C++.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//

#include <iostream>
#include "encabezado.h"
#include <conio.h>
#include <windows.h>

#define uchar unsigned char
#define uint unsigned int

int main()
{
    bool end = false;
    bool trama_ok = false;
    uchar cadena[10];
    int i = 0;
    operacio Obj;
    while (!end)
    {
        printf("Escriu import de la divisa que vulguis cambiar:\n\r");
        do
        {
            if (_kbhit())
            {
                uchar a = _getch();
                switch (a)
                {
                case 27: //si es per ESC
                    end = true;
                    trama_ok = true;
                    break;
                case 13: //si es prem ENTER
                    trama_ok = true;
                    printf("\n\r");
                    break;
                default:
                    cadena[i] = a;
                    printf("%c", a);
                    i++;
                    break;
                }
            }
        } while (!trama_ok);
        if (end)
        {
            printf("Aplicacio finalitzada\n\r");
            return 0;
        }
        char* end;
        trama_ok = false;
        float valor = strtof((const char*)cadena, &end);
        if (*end == '\0' || valor < 0) 
        {
            printf("Import introduit no valid\n\r");
        }
        else 
        {
            if (cadena[i-1] == 'e')
            {
                printf("El valor introduit es %.2f e --> %.2f d \n \r\n\r", valor, Obj.EuroToDollar(valor));
            }
            else if(cadena[i-1] == 'd')
            {
                printf("El valor introduit es %.2f d --> %.2f e\n \r\n\r", valor, Obj.DollarToEuro(valor));
            }
            else
            {
                printf("No s'ha detectat la divisa o no suportem aquesta divisa encara\n \r\n \r");
            }
        }
        for (int j = 0; j < i; j++)
        {
            cadena[j] = '\0';
        }
        i = 0;
    }

    return 0;
}

// Ejecutar programa: Ctrl + F5 o menú Depurar > Iniciar sin depurar
// Depurar programa: F5 o menú Depurar > Iniciar depuración

// Sugerencias para primeros pasos: 1. Use la ventana del Explorador de soluciones para agregar y administrar archivos
//   2. Use la ventana de Team Explorer para conectar con el control de código fuente
//   3. Use la ventana de salida para ver la salida de compilación y otros mensajes
//   4. Use la ventana Lista de errores para ver los errores
//   5. Vaya a Proyecto > Agregar nuevo elemento para crear nuevos archivos de código, o a Proyecto > Agregar elemento existente para agregar archivos de código existentes al proyecto
//   6. En el futuro, para volver a abrir este proyecto, vaya a Archivo > Abrir > Proyecto y seleccione el archivo .sln
