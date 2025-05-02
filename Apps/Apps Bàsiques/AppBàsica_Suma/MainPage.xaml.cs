namespace Prova_TFG
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBtnSumaClicked(object sender, EventArgs e)
        {
            try
            {
                int n1 = int.Parse(Numero1.Text);
                int n2 = int.Parse(Numero2.Text);
                int res = n1 + n2;
                NumeroR.Text = Convert.ToString(res);
            }
            catch (Exception ex)
            {
                NumeroR.Text = "Error: " + ex.Message;
            }
        }
    }

}
