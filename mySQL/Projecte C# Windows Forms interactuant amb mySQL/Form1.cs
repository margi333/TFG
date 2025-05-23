using System.Globalization;
using MySql.Data.MySqlClient;
namespace _3_Curs_C__i_mySQL
{
    using classe;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // Aquest m�tode es desencadena quan l'usuari fa clic al bot� de cerca.
        // La seva funci� �s buscar un producte a la base de dades a partir del codi introdu�t.
        private void button1_Click(object sender, EventArgs e)
        {
            // S'obt� el codi del producte des del control de text.
            string codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            // Es crea la consulta SQL per cercar el producte per ID. (*Nota: Vulnerable a injecci� SQL*)
            string sql = "SELECT * FROM productes WHERE id LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                // S'executa la consulta i es llegeixen els resultats.
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Es mostren les dades del producte en els controls de formulari.
                        txtNombre.Text = reader.GetString(1);
                        txtDescripcion.Text = reader.GetString(2);
                        txtPrecioPublico.Text = reader.GetDecimal(3).ToString("F1", CultureInfo.InvariantCulture);
                        txtExistencias.Text = reader.GetInt16(4).ToString();
                    }
                }
                else
                {
                    // Missatge si no es troba cap registre.
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                // Gesti� d'errors en la connexi� o execuci� SQL.
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
            finally
            {
                // Es tanca la connexi� amb la base de dades.
                conexionBD.Close();
            }
        }

        // Esdeveniment que es produeix en carregar el formulari. (Actualment sense funcionalitat)
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Aquest m�tode permet inserir un nou producte a la base de dades.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Es recuperen els valors dels controls de formulari.
            string descripcion = txtDescripcion.Text;
            string nombre = txtNombre.Text;
            double precio_publico = 0;
            int existencias = 0;

            try
            {
                // Conversi� i validaci� dels valors introdu�ts.
                precio_publico = double.Parse(txtPrecioPublico.Text);
                existencias = int.Parse(txtExistencias.Text);
                Limpiar();
            }
            catch (FormatException ex)
            {
                // Si el format �s incorrecte, es mostra un missatge d'error.
                MessageBox.Show("Error: " + ex.Message);
                Limpiar();
                return;
            }

            // Validaci� de camps obligatoris abans de guardar.
            if (nombre != "" && descripcion != "" && precio_publico > 0 && existencias > 0)
            {
                // Consulta SQL per inserir un nou registre. (*Nota: Vulnerable a injecci� SQL*)
                string sql = "INSERT INTO productes (nom, descripcio, preu, existencies) VALUES ( '" + nombre + "', '" + descripcion + "', '" + precio_publico + "', '" + existencias + "')";
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    // Execuci� de la comanda SQL.
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro guardado");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos o no son correctos");
            }
        }

        // Aquest m�tode permet actualitzar un producte ja existent a la base de dades.
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string descripcion = txtDescripcion.Text;
            string nombre = txtNombre.Text;
            double precio_publico = 0;
            int existencias = 0;

            try
            {
                precio_publico = double.Parse(txtPrecioPublico.Text, CultureInfo.InvariantCulture);
                existencias = int.Parse(txtExistencias.Text);
                Limpiar();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Limpiar();
                return;
            }

            if (nombre != "" && descripcion != "" && precio_publico > 0 && existencias > 0)
            {
                // Consulta SQL per modificar un producte existent. (*Nota: Vulnerable a injecci� SQL*)
                string sql = "UPDATE productes SET nom='" + nombre + "', descripcio='" + descripcion +
                       "', preu='" + precio_publico.ToString(CultureInfo.InvariantCulture) + "', existencies='" + existencias + "' WHERE id='" + codigo + "'";
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message);
                }
                finally
                {
                    conexionBD.Close();
                }
            }
            else
            {
                MessageBox.Show("Faltan datos o no son correctos");
            }
        }

        // Aquest m�tode elimina un producte de la base de dades en funci� del seu ID.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtCodigo.Text;

            // Consulta SQL per eliminar el registre. (*Nota: Vulnerable a injecci� SQL*)
            string sql = "DELETE FROM productes WHERE id='" + id + "'";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
                Limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        // Aquest m�tode es crida quan l'usuari vol esborrar tots els camps del formulari.
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // Funci� auxiliar per buidar tots els controls de text del formulari.
        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencias.Text = "";
        }


        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
