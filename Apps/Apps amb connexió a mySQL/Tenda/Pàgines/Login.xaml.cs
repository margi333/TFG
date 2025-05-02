namespace Tenda
{
    using System.Globalization;
    using MySql.Data.MySqlClient;
    using Tenda.Pàgines;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        private async void EntryBtnClicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            app.Info.email = correu.Text;
            MySqlDataReader reader1 = null;

            string sql1 = "SELECT * FROM login WHERE email LIKE '" + correu.Text + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
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
                        correu_sql = reader1.GetString(1);
                    }
                    reader1.Close();
                    if(correu_sql.Equals(app.Info.email.ToLower().Trim()))
                    {
                        MySqlDataReader reader2 = null;
                        string sql2 = "SELECT * FROM login WHERE contrasenya LIKE '" + contrasenya.Text + "' LIMIT 1";
                        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
                        reader2 = comando2.ExecuteReader();
                        string? contra_sql = "";
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                contra_sql = reader2.GetString(2);
                            }
                            if (contra_sql.Equals(contrasenya.Text.Trim()))
                            {
                                Preferences.Set("IsLoggedIn", true);
                                reader2.Close();
                                conexionBD.Close();
                                Preferences.Set("Email", app.Info.email);
                                Application.Current.MainPage = new AppShell();
                            }
                        }
                        else
                        {
                            await DisplayAlert("Error!", "No estas registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error!", "No estas registrat o el correu o la contrasenya és incorrecta!", "D'acord");
                }
            }
            catch (MySqlException ex)
            {
                await DisplayAlert("Error!", ex.Message, "D'acord");
            }
            finally
            {
                conexionBD.Close();
            }
        }
        private void RegisterBtnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NewUser();
        }
    }

}
