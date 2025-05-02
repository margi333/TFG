namespace Tenda;

    using System;
    public partial class Camisetes : ContentPage
    {
        public Camisetes()
        {
            InitializeComponent();
        }
        private void NikeBtnClicked(object sender, EventArgs e)
        {
            // Fer visible la finestra emergent

            popup.IsVisible = true;
            popup.Nom_Element = "Samarreta Nike:";
            popup.Nom_Imatge = "camiseta_nike.jpg";
            popup.Color1 = "Vermell";
            popup.Color2 = "Blau";
            popup.Color3 = "Verd";
            popup.ActualitzaColors();
        }
        private void AdidasBtnClicked(object sender, EventArgs e)
        {
            // Fer visible la finestra emergent
            popup.Nom_Element = "Samarreta Adidas:";
            popup.Nom_Imatge = "camiseta_adidas.jpg";
            popup.Color1 = "Blanca/Negra";
            popup.Color2 = "Negra/blanca";
            popup.Color3 = "Blava/blanca";
            popup.ActualitzaColors();
            popup.IsVisible = true;
        }
        private void PumaBtnClicked(object sender, EventArgs e)
        {
            // Fer visible la finestra emergent
            popup.IsVisible = true;
            popup.Nom_Element = "Samarreta Puma:";
            popup.Nom_Imatge = "camiseta_puma.jpg";
            popup.Color1 = "Blau";
            popup.Color2 = "Vermell";
            popup.Color3 = "Verd";
            popup.ActualitzaColors();
        }
    }