namespace Tenda
{
    using System.Globalization;
    using MySql.Data.MySqlClient;     // Llibreria per accedir a bases de dades MySQL
    using Tenda.Pàgines;              // Espai de noms on es troben altres pàgines de l'app

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();     // Inicialitza els components visuals de la pàgina (definits a XAML)
        }

        // Mètode cridat quan l’usuari fa clic al botó “Entrar”
        private async void EntryBtnClicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            app.Info.email = correu.Text; // Guarda l’email introduït a una propietat global
            MySqlDataReader reader1 = null;

            // Consulta per comprovar si l’email existeix a la base de dades
            string sql1 = "SELECT * FROM login WHERE email LIKE '" + correu.Text + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion(); // Obté la connexió
            conexionBD.Open();

            try
            {
                MySqlCommand comando1 = new MySqlCommand(sql1, conexionBD);
                reader1 = comando1.ExecuteReader();

                string? correu_sql = "";

                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        correu_sql = reader1.GetString(1); // Agafa el correu de la base de dades
                    }
                    reader1.Close(); // Tanquem el primer lector per fer una nova consulta

                    // Compara el correu introduït amb el que hi ha a la BBDD
                    if (correu_sql.Equals(app.Info.email.ToLower().Trim()))
                    {
                        MySqlDataReader reader2 = null;

                        // Consulta per comprovar si la contrasenya coincideix (⚠️ mal enfocada: ho veurem avall)
                        string sql2 = "SELECT * FROM login WHERE contrasenya LIKE '" + contrasenya.Text + "' LIMIT 1";
                        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
                        reader2 = comando2.ExecuteReader();

                        string? contra_sql = "";

                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                contra_sql = reader2.GetString(2); // Agafa la contrasenya de la BBDD
                            }

                            // Compara contrasenya introduïda amb la de la BBDD
                            if (contra_sql.Equals(contrasenya.Text.Trim()))
                            {
                                Preferences.Set("IsLoggedIn", true); // Guarda estat de sessió
                                reader2.Close();
                                conexionBD.Close();
                                Preferences.Set("Email", app.Info.email); // Guarda correu de l’usuari
                                Application.Current.MainPage = new AppShell(); // Redirigeix a la pàgina principal
                            }
                        }
                        else
                        {
                            await DisplayAlert("Error!", "No estàs registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error!", "No estàs registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                }
            }
            catch (MySqlException ex)
            {
                await DisplayAlert("Error!", ex.Message, "D'acord");
            }
            finally
            {
                conexionBD.Close(); // Tanca la connexió a la base de dades
            }
        }

        // Redirigeix a la pàgina de registre d’usuari
        private void RegisterBtnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NewUser();
        }
    }
}
