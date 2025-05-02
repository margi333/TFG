#include <mysql_driver.h>        // Driver de MySQL
#include <mysql_connection.h>    // Connexió a MySQL
#include <cppconn/statement.h>   // Per executar consultes SQL
#include <cppconn/resultset.h>   // Per gestionar resultats de consultes
#include <cppconn/prepared_statement.h>  // Per consultes preparades

using namespace std;

class Connexio
{
public:
	static sql::Connection* conexion()
	{
		try
		{
			//Obtenim el driver
			sql::mysql::MySQL_Driver* driver = sql::mysql::get_mysql_driver_instance();

			//Connexió
			sql::Connection* conn = driver->connect("tcp://127.0.0.1:3306", "root", "Mam@vi2003");

			//seleccio de base de dades
			conn->setSchema("tenda");

			return conn;
		}
		catch (sql::SQLException e)
		{
			return nullptr;
		}
	}
};