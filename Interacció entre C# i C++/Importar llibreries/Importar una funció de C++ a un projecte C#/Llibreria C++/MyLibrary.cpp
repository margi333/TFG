// MyLibrary.cpp : Define las funciones exportadas del archivo DLL.
//

#include "pch.h"
#include "framework.h"
#include "MyLibrary.h"

// Ejemplo de variable exportada
MYLIBRARY_API int nMyLibrary=0;

// Ejemplo de función exportada.
MYLIBRARY_API int fnMyLibrary(void)
{
    return 0;
}

// Constructor de clase exportada.
CMyLibrary::CMyLibrary()
{
    return;
}
int suma(int a, int b)
{
	return a + b;
}

