using MySql.Data.MySqlClient;

namespace Tenda;

public partial class PaginaSecundaria : ContentPage
{
    public string? Nom { get; set; } = "";
    private bool inici = true;
    public PaginaSecundaria()
	{
		InitializeComponent();
        if(inici)
        {
            inici = false;
            Inici_Nom();
        }
    }
    private void Inici_Nom()
    {
        MySqlConnection conexionBD = Conexion.conexion();
        conexionBD.Open();
        MySqlDataReader reader2 = null;
        var app = Application.Current as App;
        string sql2 = "SELECT nom FROM login WHERE email LIKE '" + Preferences.Get("Email", app.Info.email) + "' LIMIT 1";
        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
        reader2 = comando2.ExecuteReader();
        string? nom_sql = "";
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                nom_sql = reader2.GetString("nom");
            }
            app.Info.nom = nom_sql;
        }
        Nom = app.Info.nom;
        BindingContext = this;
    }
    private async void CamisetesBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///camisetes");
    }
    private async void PantalonsBtnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///pantalons");
    }
    private async void LogOutBtnClicked(object sender, EventArgs e)
    {
        Preferences.Set("IsLoggedIn", false);
        await DisplayAlert("Éxit!", "Has tancat sessió correctament", "Acceptar");
        Application.Current.MainPage = new MainPage();
    }
}