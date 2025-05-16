namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // M�tode que s'executa quan l'usuari fa clic al bot� per realitzar una operaci� aritm�tica (suma o resta)
        private void btnOperacio_Click(object sender, EventArgs e)
        {
            // S'obtenen els valors introdu�ts als dos controls de text
            string num1 = txtNum1.Text;
            string num2 = txtNum2.Text;

            try
            {
                // Es converteixen les cadenes a enters
                int n1 = int.Parse(num1);
                int n2 = int.Parse(num2);

                // S'utilitza un switch per determinar quina operaci� ha seleccionat l'usuari al ComboBox
                switch (ComboBox.SelectedIndex)
                {
                    case 0: // Cas de la suma
                        MessageBox.Show("La suma de " + n1 + " + " + n2 + " = " + (n1 + n2));
                        break;

                    case 1: // Cas de la resta
                        MessageBox.Show("La resta de " + n1 + " - " + n2 + " = " + (n1 - n2));
                        break;

                    default: // Cap opci� seleccionada
                        MessageBox.Show("Selecciona una operaci�");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Si hi ha un error en la conversi� (per exemple, si s'introdueixen car�cters no num�rics), es mostra un missatge d'error
                MessageBox.Show("Error: " + ex.Message);
            }

            // Es netegen els camps de text independentment de si l�operaci� ha tingut �xit o no
            Clean();
        }

        // M�tode auxiliar que neteja els controls de text despr�s de l'operaci�
        private void Clean()
        {
            txtNum1.Text = "";
            txtNum2.Text = "";
        }

    }
}
