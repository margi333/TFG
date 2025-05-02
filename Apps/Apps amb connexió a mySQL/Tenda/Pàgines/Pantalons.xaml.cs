namespace Tenda;

public partial class Pantalons : ContentPage
{
	public Pantalons()
	{
		InitializeComponent();
	}
    private void NikeBtnClicked(object sender, EventArgs e)
    {
        // Fer visible la finestra emergent
        popup.IsVisible = true;
        popup.Nom_Element = "Pantalons Nike:";
        popup.Nom_Imatge = "pantalons_nike.jpg";
        popup.Color1 = "Vermell";
        popup.Color2 = "Blau";
        popup.Color3 = "Verd";
        popup.ActualitzaColors();
    }
    private void AdidasBtnClicked(object sender, EventArgs e)
    {
        // Fer visible la finestra emergent
        popup.Nom_Element = "Pantalons Adidas:";
        popup.Nom_Imatge = "pantalons_adidas.jpg";
        popup.Color1 = "Blau";
        popup.Color2 = "Vermell";
        popup.Color3 = "Verd";
        popup.ActualitzaColors();
        popup.IsVisible = true;
    }
    private void PumaBtnClicked(object sender, EventArgs e)
    {
        // Fer visible la finestra emergent
        popup.IsVisible = true;
        popup.Nom_Element = "Pantalons Puma:";
        popup.Nom_Imatge = "pantalons_puma.jpg";
        popup.Color1 = "Negre";
        popup.Color2 = "Vermell";
        popup.Color3 = "Blau";
        popup.ActualitzaColors();
    }
}