using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tenda
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {

            string cadenaConexion = "Server=b66sc16ukbx8esvherym-mysql.services.clever-cloud.com;Port=3306;Database=b66sc16ukbx8esvherym;User ID=u39oqxqf8ddgqsyx;Password=IgUhpFGXUGPcDlmFivmu;";



            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
    }
}
