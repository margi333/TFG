using MySql.Data.MySqlClient;

namespace Fitxar
{
    public partial class MainPage : ContentPage
    {
        int count = 0; // Variable que no s'utilitza en aquest fragment

        public MainPage()
        {
            InitializeComponent(); // Inicialitza els components visuals (XAML)
        }

        // Mètode que s'executa quan l'usuari fa clic al botó d'entrada (login)
        private async void EntryBtnClicked(object sender, EventArgs e)
        {
            var app = Application.Current as App; // Obté l’instància global de l’app
            app.Obj.email = correu.Text; // Desa el correu introduït en l’objecte global

            MySqlDataReader reader1 = null;

            // Consulta SQL per comprovar si el correu existeix a la taula "treballadors"
            string sql1 = "SELECT * FROM treballadors WHERE email_treballador LIKE '" + correu.Text + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando1 = new MySqlCommand(sql1, conexionBD);
                reader1 = comando1.ExecuteReader();
                string? correu_sql = "";

                if (reader1.HasRows)
                {
                    // Llegeix el correu trobat
                    while (reader1.Read())
                    {
                        correu_sql = reader1.GetString("email_treballador");
                    }
                    reader1.Close();

                    // Compara el correu llegit amb el que ha introduït l’usuari
                    if (correu_sql.Equals(app.Obj.email.ToLower().Trim()))
                    {
                        MySqlDataReader reader2 = null;

                        // Consulta per verificar la contrasenya
                        string sql2 = "SELECT * FROM treballadors WHERE contrasenya_treballador LIKE '" + contrasenya.Text + "' LIMIT 1";
                        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
                        reader2 = comando2.ExecuteReader();
                        string? contra_sql = "";

                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                contra_sql = reader2.GetString("contrasenya_treballador");
                            }

                            // Compara la contrasenya introduïda amb la de la base de dades
                            if (contra_sql.Equals(contrasenya.Text.Trim()))
                            {
                                // S’ha fet login correctament
                                Preferences.Set("IsLoggedIn", true);

                                // Desa el nom de la taula associada a l’usuari
                                app.Obj.nom_BD = reader2.GetString("nomTAULA_treballador");

                                reader2.Close();
                                conexionBD.Close();

                                // Desa les preferències per mantenir la sessió
                                Preferences.Set("DB", app.Obj.nom_BD);
                                Preferences.Set("Email", app.Obj.email);

                                // Redirigeix a la pàgina principal de l’aplicació
                                Application.Current.MainPage = new AppShell();
                            }
                        }
                        else
                        {
                            // Error si la contrasenya no coincideix
                            await DisplayAlert("Error!", "No estas registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                        }
                    }
                }
                else
                {
                    // Error si el correu no existeix a la base de dades
                    await DisplayAlert("Error!", "No estas registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                }
            }
            catch (MySqlException ex)
            {
                // Mostra un missatge si hi ha un error amb la connexió o consulta SQL
                await DisplayAlert("Error!", ex.Message, "D'acord");
            }
            finally
            {
                // Tanca la connexió a la base de dades en qualsevol cas
                conexionBD.Close();
            }
        }
    }
}
