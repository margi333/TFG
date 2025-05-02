#include <windows.h>
#include <stdio.h>
#include <conio.h>


typedef void (*sumaFunc)(int, int);

int main()
{
	HINSTANCE hDll = LoadLibrary(L"MyLibraryC#.dll");
	if (!hDll) {
		printf("Error carregant la DLL\n");
		return 1;
	}

	sumaFunc suma = (sumaFunc)GetProcAddress(hDll, "suma");
	if (!suma) {
		printf("No s'ha trobat la funció\n");
		return 1;
	}
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

		suma(n1, n2);
	}
	FreeLibrary(hDll);
	return 0;
}