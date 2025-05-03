using Funcio;

while (true)
{
    Console.WriteLine("Introdueix un numero");
    bool num_correcte = false;
    int num1 = 0, num2 = 0;
    do
    {
        string? n1 = Console.ReadLine();
        try
        {
            num1 = int.Parse(n1);
            num_correcte = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    } while (!num_correcte);

    Console.WriteLine("Introdueix un segon numero");
    num_correcte = false;
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

    Funcio_class Obj = new Funcio_class();

    Console.WriteLine($"El resultat de la suma és: {Obj.suma(num1, num2)}\n\r");
}
