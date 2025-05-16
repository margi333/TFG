using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definició_de_classes; // Espai de noms on es defineix la classe Operacio

// Creació de l’objecte que permet realitzar les conversions de divisa
Operacio Obj = new Operacio();
bool end = false;
string? cadena = "";

// Bucle principal que s’executa fins que l’usuari introdueix una cadena buida
while (!end)
{
    Console.WriteLine("Escriu l'import de la divisa que vulguis canviar (ex: 100e o 200d):");
    cadena = Console.ReadLine();

    // Si l'usuari prem enter sense escriure res, es finalitza el programa
    if (cadena == "")
    {
        end = true;
        break;
    }

    try
    {
        // Es separa l’últim caràcter per identificar la divisa i es processa el valor numèric
        string Newcadena = cadena.Remove(cadena.Length - 1); // Retira la lletra final
        double valor = double.Parse(Newcadena); // Converteix el valor numèric

        // Comprovació que el valor sigui positiu
        if (valor < 0)
        {
            Console.WriteLine("El valor a convertir ha de ser major a 0\n\r");
        }
        else
        {
            // Si acaba en 'e' es converteix d’euros a dòlars
            if (cadena[cadena.Length - 1] == 'e')
            {
                Console.WriteLine($"El valor introduït és {valor} e --> {Obj.EuroToDollar(valor).ToString("F2")} d\n\r");
            }
            // Si acaba en 'd' es converteix de dòlars a euros
            else if (cadena[cadena.Length - 1] == 'd')
            {
                Console.WriteLine($"El valor introduït és {valor} d --> {Obj.DollarToEuro(valor).ToString("F2")} e\n\r");
            }
            // Si no acaba ni en 'e' ni en 'd', la divisa no és reconeguda
            else
            {
                Console.WriteLine("No s'ha detectat la divisa o no suportem aquesta divisa encara\n\r");
            }
        }
    }
    catch (Exception ex)
    {
        // En cas d'error de format (ex. valor no numèric), es mostra un missatge d'error
        Console.WriteLine("Error: " + ex.Message);
    }
}

// Quan es surt del bucle, es mostra un missatge de tancament de l'aplicació
Console.WriteLine("Aplicació finalitzada");
