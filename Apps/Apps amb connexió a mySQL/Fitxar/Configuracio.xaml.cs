using MySql.Data.MySqlClient;

namespace Fitxar;

public partial class Configuracio : ContentPage
{
    public Configuracio()
    {
        InitializeComponent();
    }
    private async void Contrasenya1_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (e.NewTextValue.Any(char.IsDigit) && e.NewTextValue.Any(c => !char.IsLetterOrDigit(c)) && e.NewTextValue.Any(char.IsUpper))
        {
            val_contrasenya1.Text = "Contrasenya Forta";
            val_contrasenya1.TextColor = Colors.Green;
        }
        else
        {
            val_contrasenya1.Text = "Contrasenya Dèbil";
            val_contrasenya1.TextColor = Colors.Red;
        }
    }
    private void Contrasenya2_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals(Contrasenya1.Text))
        {
            val_contrasenya2.Text = "?";
            val_contrasenya2.TextColor = Colors.Green;
        }
        else
        {
            val_contrasenya2.Text = "?";
            val_contrasenya2.TextColor = Colors.Red;
        }
    }
    private async void ContrasenyaBtnClicked(object sender, EventArgs e)
    {
        if ((val_contrasenya1.TextColor != Colors.Green) && (val_contrasenya1.TextColor != Colors.Green))
        {
            await DisplayAlert("Error", "Comprova les contrasenyes introduïdes", "D'acord!");
        }
        else
        {
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            MySqlDataReader reader2 = null;
            var app = Application.Current as App;
            string sql2 = "SELECT contrasenya FROM treballdors WHERE email_treballador LIKE '" + Preferences.Get("Email", app.Obj.email) + "' LIMIT 1";
            MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
            reader2 = comando2.ExecuteReader();
            string? contrasenya_antiga = "";
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    contrasenya_antiga = reader2.GetString("contrasenya_treballador");
                }
            }
            reader2.Close();
            conexionBD.Close();
            if (contrasenya_antiga.Equals(Contrasenya1))
            {
                await DisplayAlert("Error", "Introdueix una contrasenya que no hagis fet servir ja", "D'acord!");
            }
            else
            {
                MySqlConnection conexionBD2 = Conexion.conexion();
                string sql = "UPDATE treballadors SET contrasenya_treballador = @novaContra WHERE email_treballador LIKE @email LIMIT 1";
                MySqlCommand comando3 = new MySqlCommand(sql, conexionBD2);
                comando3.Parameters.AddWithValue("@novaContra", Contrasenya1);
                comando3.Parameters.AddWithValue("@email", app.Obj.email);
                comando3.ExecuteNonQuery();
                conexionBD2.Close();
                await DisplayAlert("Éxit!", "Contrasenya cambiada correctament", "D'acord!");
            }
        }
    }
}