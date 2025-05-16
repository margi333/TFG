// S'importa l'espai de noms on es troba definida la classe Funcio_class
using Funcio;

// Bucle principal del programa que es repeteix indefinidament
while (true)
{
    Console.WriteLine("Introdueix un número");
    bool num_correcte = false;
    int num1 = 0, num2 = 0;

    // Validació de l’entrada del primer número
    do
    {
        string? n1 = Console.ReadLine();  // Llegeix l'entrada de l'usuari (pot ser nul·la)
        try
        {
            // Intenta convertir la cadena a enter
            num1 = int.Parse(n1);
            num_correcte = true;
        }
        catch (Exception ex)
        {
            // Si l’entrada no és vàlida, es mostra un missatge d’error
            Console.WriteLine("Error: " + ex.Message);
        }

    } while (!num_correcte);

    Console.WriteLine("Introdueix un segon número");
    num_correcte = false;

    // Validació de l’entrada del segon número
    do
    {
        string? n2 = Console.ReadLine();
        try
        {
            num2 = int.Parse(n2);
            num_correcte = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    } while (!num_correcte);

    // Creació d’un objecte de la classe Funcio_class per accedir als seus mètodes
    Funcio_class Obj = new Funcio_class();

    // Crida al mètode suma amb els dos números i mostra el resultat
    Console.WriteLine($"El resultat de la suma és: {Obj.suma(num1, num2)}\n\r");
}
