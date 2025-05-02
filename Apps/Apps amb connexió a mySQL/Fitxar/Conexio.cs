using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitxar
{
    using MySql.Data.MySqlClient;
    class Conexion
    {
        public static MySqlConnection conexion()
        {

            string cadenaConexion = "Server=bznhpmxi9fccnbiorubm-mysql.services.clever-cloud.com;Port=3306;Database=bznhpmxi9fccnbiorubm;User ID=ulnvcx1imv88fnej;Password=N5qIcmU1CTnxHMIEX23Y;";

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
