// El siguiente bloque ifdef muestra la forma estándar de crear macros que hacen la exportación
// de un DLL más sencillo. Todos los archivos de este archivo DLL se compilan con MYLIBRARY_EXPORTS
// símbolo definido en la línea de comandos. Este símbolo no debe definirse en ningún proyecto
// que use este archivo DLL. De este modo, otros proyectos cuyos archivos de código fuente incluyan el archivo verán
// interpretan que las funciones MYLIBRARY_API se importan de un archivo DLL, mientras que este archivo DLL interpreta los símbolos
// definidos en esta macro como si fueran exportados.
#ifdef MYLIBRARY_EXPORTS
#define MYLIBRARY_API __declspec(dllexport)
#else
#define MYLIBRARY_API __declspec(dllimport)
#endif

// Clase exportada del DLL
class MYLIBRARY_API CMyLibrary {
public:
	CMyLibrary(void);
	// TODO: agregar métodos aquí.
};

extern MYLIBRARY_API int nMyLibrary;

MYLIBRARY_API int fnMyLibrary(void);

extern "C"
{
	MYLIBRARY_API int suma(int a, int b);
}
