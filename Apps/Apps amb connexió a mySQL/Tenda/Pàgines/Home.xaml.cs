using MySql.Data.MySqlClient;

namespace Tenda;

public partial class PaginaSecundaria : ContentPage
{
    public string? Nom { get; set; } = ""; // Propietat pública que es vincula amb la UI per mostrar el nom
    private bool inici = true;             // Control per assegurar que la càrrega només es fa un cop

    public PaginaSecundaria()
    {
        InitializeComponent();             // Inicialitza els components visuals (XAML)

        // Carrega el nom de l’usuari només al primer cop
        if (inici)
        {
            inici = false;
            Inici_Nom();                   // Carrega el nom de la base de dades
        }
    }

    // Mètode que consulta el nom de l’usuari a partir del correu desat a Preferences
    private void Inici_Nom()
    {
        MySqlConnection conexionBD = Conexion.conexion(); // Obté la connexió a la BBDD
        conexionBD.Open();
        MySqlDataReader reader2 = null;
        var app = Application.Current as App;

        // Consulta per obtenir el nom de l’usuari que ha iniciat sessió
        string sql2 = "SELECT nom FROM login WHERE email LIKE '" + Preferences.Get("Email", app.Info.email) + "' LIMIT 1";

        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
        reader2 = comando2.ExecuteReader();

        string? nom_sql = "";

        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                nom_sql = reader2.GetString("nom"); // Llegeix el nom de l’usuari
            }

            app.Info.nom = nom_sql; // Desa el nom a l’objecte global Info
        }

        Nom = app.Info.nom; // Assigna el nom per mostrar-lo a la interfície
        BindingContext = this; // Estableix la pàgina com a font de dades (per al binding)
    }

    // Navega a la pàgina de "camisetes"
    private async void CamisetesBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///camisetes");
    }

    // Navega a la pàgina de "pantalons"
    private async void PantalonsBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///pantalons");
    }

    // Tanca sessió de l’usuari
    private async void LogOutBtnClicked(object sender, EventArgs e)
    {
        Preferences.Set("IsLoggedIn", false); // Desactiva la sessió
        await DisplayAlert("Èxit!", "Has tancat sessió correctament", "Acceptar");
        Application.Current.MainPage = new MainPage(); // Torna a la pàgina de login
    }
}
