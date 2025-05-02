using MySql.Data.MySqlClient;

namespace Curs_de_connexió_C__amb_mySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servidor = txtServidor.Text;
            string puerto = txtPuerto.Text;
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string BD = txtBd.Text;

            string cadenaConexion = "Database="+BD+"; Data Source=" + servidor + "; Port=" + puerto + "; User Id=" + usuario + ";Password=" + password;

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;
            string data = null;

            try
            {
                string consulta = "SELECT * FROM categoria";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    data += reader.GetInt16(0) + "\n";
                }

                MessageBox.Show(data);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }
    }
}
