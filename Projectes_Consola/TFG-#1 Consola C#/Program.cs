
namespace Definició_de_classes
{
    class Operacio
    {
	public double EuroToDollar(double valor)
        {
            if (valor > 0)
            {
                return valor * 1.05;
            }
            return 0;
        }
    public double DollarToEuro(double valor)
        {
            if (valor > 0)
            {
                return valor / 1.05;
            }
            return 0;
        }
    };
}