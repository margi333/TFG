using System.Text.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tenda.Pàgines;

public partial class NewUser : ContentPage
{
    public NewUser()
    {
        InitializeComponent();
    }
    public async Task<bool> EsAdrecaReal(string adreca)
    {
        string apiKey = "LaTevaClauAPI";
        string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(adreca)}&key={apiKey}";

        using var client = new HttpClient();
        try
        {
            var resposta = await client.GetStringAsync(url);
            var json = JsonDocument.Parse(resposta);

            // Si hi ha resultats, l'adreça és vàlida
            return json.RootElement.GetProperty("results").GetArrayLength() > 0;
        }
        catch
        {
            return false;
        }
    }

    private bool EsEmailValid(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
    private void correu1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (EsEmailValid(e.NewTextValue))
        {
            val_correu1.Text = "✅";
            val_correu1.TextColor = Colors.Green;
        }
        else
        {
            val_correu1.Text = "❌";
            val_correu1.TextColor = Colors.Red;
        }
    }
    private void correu2_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals(correu1.Text))
        {
            val_correu2.Text = "✅";
            val_correu2.TextColor = Colors.Green;
        }
        else
        {
            val_correu2.Text = "❌";
            val_correu2.TextColor = Colors.Red;
        }
    }

    private async void telefon_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (e.NewTextValue.Length == 9)
        {
            val_telefon.Text = "✅";
            val_telefon.TextColor = Colors.Green;
        }
        else
        {
            val_telefon.Text = "❌";
            val_telefon.TextColor = Colors.Red;
        }
    }
    private async void contrasenya_TextChanged(object sender, TextChangedEventArgs e)
    {

        if (e.NewTextValue.Any(char.IsDigit) && e.NewTextValue.Any(c => !char.IsLetterOrDigit(c)) && e.NewTextValue.Any(char.IsUpper))
        {
            val_contrasenya.Text = "Contrasenya Forta";
            val_contrasenya.TextColor = Colors.Green;
        }
        else
        {
            val_contrasenya.Text = "Contrasenya Dèbil";
            val_contrasenya.TextColor = Colors.Red;
        }
    }
    private void LoginBtnClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }
    private async void CrearBtnClicked(object sender, EventArgs e)
    {
        if (nom.Text.Length == 0)
        {
            await DisplayAlert("Error!", "Introdueix algun nom", "D'acord");
            return;
        }
        if (!EsEmailValid(correu1.Text))
        {
            await DisplayAlert("Error!", "Correu no vàlid", "D'acord");
            return;
        }
        if (!correu1.Text.Trim().Equals(correu2.Text.Trim()))
        {
            await DisplayAlert("Error!", "Correus introduïts no iguals", "D'acord");
            return;
        }
        if (telefon.Text.Length != 9)
        {
            await DisplayAlert("Error!", "Número de telèfon introduït no vàlid", "D'acord");
            return;
        }
        if (contrasenya.Text.Length == 0)
        {
            await DisplayAlert("Error!", "Introdueix una contrasenya!", "D'acord");
            return;
        }

        string adreca = adreça.Text;
        bool adrecaValida = await EsAdrecaReal(adreca);
        if (adrecaValida)
        {
            await DisplayAlert("Error!", "Adreça introduïda no vàlida", "D'acord");
            return;
        }

        MySqlConnection conexionBD = null;
        try
        {
            // Connexió a la base de dades
            conexionBD = Conexion.conexion();
            conexionBD.Open();

            // Comprovem si l'email ja existeix a la base de dades
            string sql1 = "SELECT email FROM login WHERE email = @correu LIMIT 1";
            MySqlCommand comando1 = new MySqlCommand(sql1, conexionBD);
            comando1.Parameters.AddWithValue("@correu", correu1.Text);

            MySqlDataReader reader1 = comando1.ExecuteReader();
            if (reader1.HasRows)
            {
                await DisplayAlert("Error", "Ja tens un compte vinculat en aquest correu", "Acceptar");
                reader1.Close(); // Assegurem-nos de tancar el reader després d'usar-lo
                return;
            }
            reader1.Close();

            // Inserim la nova entrada a la base de dades
            string sql = "INSERT INTO login (email, contrasenya, telefon, adreça, nom) VALUES (@correu, @contrasenya, @telefon, @adreca, @nom)";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);

            // Afegim els paràmetres per a la inserció
            comando.Parameters.AddWithValue("@correu", correu1.Text);
            comando.Parameters.AddWithValue("@contrasenya", contrasenya.Text);
            comando.Parameters.AddWithValue("@telefon", telefon.Text);
            comando.Parameters.AddWithValue("@adreca", adreça.Text);
            comando.Parameters.AddWithValue("@nom", nom.Text);

            comando.ExecuteNonQuery();

            // Notifiquem a l'usuari que l'operació ha estat correcta
            await DisplayAlert("Èxit!", "Conta creada!", "D'acord");

            // Redirigim a la pàgina principal
            Application.Current.MainPage = new MainPage();
        }
        catch (MySqlException ex)
        {
            await DisplayAlert("Error", ex.Message, "D'acord");
        }
        catch (Exception ex)
        {
            // Captura qualsevol altre error no relacionat amb MySQL
            await DisplayAlert("Error", "Un error inesperat va ocórrer: " + ex.Message, "D'acord");
        }
        finally
        {
            if (conexionBD != null && conexionBD.State == System.Data.ConnectionState.Open)
            {
                conexionBD.Close();
            }
        }
    }

}