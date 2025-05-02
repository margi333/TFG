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

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT * FROM productes WHERE id LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtNombre.Text = reader.GetString(1);
                        txtDescripcion.Text = reader.GetString(2);
                        txtPrecioPublico.Text = reader.GetDecimal(3).ToString("F1", CultureInfo.InvariantCulture);
                        txtExistencias.Text = reader.GetInt16(4).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string nombre = txtNombre.Text;
            double precio_publico = 0;
            int existencias = 0;
            try
            {
                precio_publico = double.Parse(txtPrecioPublico.Text);
                existencias = int.Parse(txtExistencias.Text);
                Limpiar();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Limpiar();
                return;
            }
            if (nombre != "" && descripcion != "" && precio_publico > 0 && existencias > 0)
            {
                string sql = "INSERT INTO productes (nom, descripcio, preu, existencies) VALUES ( '" + nombre + "', '" + descripcion + "', '" + precio_publico + "', '" + existencias + "')";
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();

                try
                {
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = txtCodigo.Text;

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

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
