// Aplicació simple consola C++.cpp : Este archivo contiene la función "main". La ejecución del programa comienza y termina ahí.
//
#include <windows.h>
#include <stdio.h>
#include <conio.h>

#include "Header.h";

int main()
{
	while (true)
	{
		printf("Introdueix un numero del 0 al 9\n\r");
		bool num_valid = false;
		char num1, num2;
		const char* apunt_n1 = &num1;
		const char* apunt_n2 = &num2;
		int n1, n2;
		while (!num_valid)
		{
			if (_kbhit())
			{
				char a = _getch();
				if (a < 48 || a > 57)
				{
					printf("Introdueix un numero dins del rang\n\r");
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
				if (a < 48 || a > 57)
				{
					printf("Introdueix un numero dins del rang\n\r");
				}
				else
				{
					num2 = a;
					num_valid = true;
				}
			}
		}
		n2 = atoi(apunt_n2);

		printf("El resultat de la suma es %d\n\r\n\r", suma(n1, n2));
	}
}


