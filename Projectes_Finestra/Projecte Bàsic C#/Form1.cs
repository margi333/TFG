namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperacio_Click(object sender, EventArgs e)
        {
            string num1 = txtNum1.Text;
            string num2 = txtNum2.Text;
            try
            {
                int n1 = int.Parse(num1);
                int n2 = int.Parse(num2);
                switch(ComboBox.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("La suma de " + n1 + " + " + n2 + " = " + (n1 + n2));
                        break;
                    case 1:
                        MessageBox.Show("La resta de " + n1 + " - " + n2 + " = " + (n1 - n2));
                        break;
                    default:
                        MessageBox.Show("Selecciona una operació");
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            Clean();
        }
        private void Clean()
        {
            txtNum1.Text = "";
            txtNum2.Text = "";
        }
    }
}
