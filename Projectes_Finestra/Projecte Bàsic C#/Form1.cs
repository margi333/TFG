namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Mètode que s'executa quan l'usuari fa clic al botó per realitzar una operació aritmètica (suma o resta)
        private void btnOperacio_Click(object sender, EventArgs e)
        {
            // S'obtenen els valors introduïts als dos controls de text
            string num1 = txtNum1.Text;
            string num2 = txtNum2.Text;

            try
            {
                // Es converteixen les cadenes a enters
                int n1 = int.Parse(num1);
                int n2 = int.Parse(num2);

                // S'utilitza un switch per determinar quina operació ha seleccionat l'usuari al ComboBox
                switch (ComboBox.SelectedIndex)
                {
                    case 0: // Cas de la suma
                        MessageBox.Show("La suma de " + n1 + " + " + n2 + " = " + (n1 + n2));
                        break;

                    case 1: // Cas de la resta
                        MessageBox.Show("La resta de " + n1 + " - " + n2 + " = " + (n1 - n2));
                        break;

                    default: // Cap opció seleccionada
                        MessageBox.Show("Selecciona una operació");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Si hi ha un error en la conversió (per exemple, si s'introdueixen caràcters no numèrics), es mostra un missatge d'error
                MessageBox.Show("Error: " + ex.Message);
            }

            // Es netegen els camps de text independentment de si l’operació ha tingut èxit o no
            Clean();
        }

        // Mètode auxiliar que neteja els controls de text després de l'operació
        private void Clean()
        {
            txtNum1.Text = "";
            txtNum2.Text = "";
        }

    }
}
