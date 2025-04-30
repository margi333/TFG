
class operacio
{
public:
	float EuroToDollar(int valor)
	{
		if (valor > 0)
		{
			return valor * 1.05;
		}
	}
	float DollarToEuro(int valor)
	{
		if (valor > 0)
		{
			return valor / 1.05;
		}
	}
}; 
