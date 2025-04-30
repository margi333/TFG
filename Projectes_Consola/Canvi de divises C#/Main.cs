using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definició_de_classes;

    Operacio Obj = new Operacio();
    bool end = false;
    string? cadena = "";
    while (!end)
    {
        Console.WriteLine("Escriu import de la divisa que vulguis cambiar:");
        cadena = Console.ReadLine();
        if (cadena == "")
        {
            end = true;
            break;
        }
        try
        {
            string Newcadena = cadena.Remove(cadena.Length - 1);
            double valor = double.Parse(Newcadena);
            if (valor < 0)
            {
                Console.WriteLine("El valor a convertir ha de ser major a 0\n \r");
            }
            else
            {
                if (cadena[cadena.Length - 1] == 'e')
                {
                    Console.WriteLine($"El valor introduit es {valor} e --> {Obj.EuroToDollar((valor)).ToString("F2")} d \n \r");
                }
                else if (cadena[cadena.Length - 1] == 'd')
                {
                    Console.WriteLine($"El valor introduit es {valor} d --> {Obj.DollarToEuro((valor)).ToString("F2")} e\n \r");
                }
                else
                {
                    Console.WriteLine("No s'ha detectat la divisa o no suportem aquesta divisa encara\n \r");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    Console.WriteLine("Aplicacio finalitzada");

