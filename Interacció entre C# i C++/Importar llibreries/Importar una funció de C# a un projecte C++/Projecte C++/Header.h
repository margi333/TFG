#pragma once

#ifdef MYLIBRARY_EXPORTS
#define MYLIBRARY_API __declspec(dllexport)
#else
#define MYLIBRARY_API __declspec(dllimport)
#endif

//  Evita el "name mangling" per compatibilitat amb C#
extern "C" {
    MYLIBRARY_API int Suma(int a, int b);
}
