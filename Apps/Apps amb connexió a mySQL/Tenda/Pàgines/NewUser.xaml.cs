using System.Text.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Tenda.Pàgines;

public partial class NewUser : ContentPage
{
    public NewUser()
    {
        InitializeComponent();
    }

    // 🔐 Valida si una adreça existeix fent consulta a l’API de Google Maps
    public async Task<bool> EsAdrecaReal(string adreca)
    {
        string apiKey = "LaTevaClauAPI"; // RECOMANAT: Desa-ho com a secret/configuració
        string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(adreca)}&key={apiKey}";

        using var client = new HttpClient();
        try
        {
            var resposta = await client.GetStringAsync(url);
            var json = JsonDocument.Parse(resposta);
            return json.RootElement.GetProperty("results").GetArrayLength() > 0;
        }
        catch
        {
            return false;
        }
    }

    // Comprova si el correu té un format vàlid
    private bool EsEmailValid(string email)
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }

    // Mostra validació visual del primer correu
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

    // Comprova si el segon correu coincideix amb el primer
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

    // Valida que el número de telèfon tingui 9 xifres
    private void telefon_TextChanged(object sender, TextChangedEventArgs e)
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

    // Avalua la força de la contrasenya (mínim: dígit, majúscula, símbol)
    private void contrasenya_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Any(char.IsDigit) &&
            e.NewTextValue.Any(c => !char.IsLetterOrDigit(c)) &&
            e.NewTextValue.Any(char.IsUpper))
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

    // Torna al login
    private void LoginBtnClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new MainPage();
    }

    // 🔐 Hash de la contrasenya amb SHA256
    private string HashContrasenya(string contrasenya)
    {
        using var sha256 = SHA256.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(contrasenya);
        byte[] hashBytes = sha256.ComputeHash(inputBytes);
        return Convert.ToBase64String(hashBytes);
    }

    // Crea un usuari nou a la base de dades
    private async void CrearBtnClicked(object sender, EventArgs e)
    {
        // Validacions bàsiques
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
            await DisplayAlert("Error!", "Els correus no coincideixen", "D'acord");
            return;
        }

        if (telefon.Text.Length != 9)
        {
            await DisplayAlert("Error!", "Número de telèfon no vàlid", "D'acord");
            return;
        }

        if (contrasenya.Text.Length == 0)
        {
            await DisplayAlert("Error!", "Introdueix una contrasenya", "D'acord");
            return;
        }

        if (!await EsAdrecaReal(adreça.Text))
        {
            await DisplayAlert("Error!", "Adreça no vàlida", "D'acord");
            return;
        }

        MySqlConnection conexionBD = null;

        try
        {
            conexionBD = Conexion.conexion();
            conexionBD.Open();

            // Comprovació d’usuari existent
            string sql1 = "SELECT email FROM login WHERE email = @correu LIMIT 1";
            MySqlCommand comando1 = new MySqlCommand(sql1, conexionBD);
            comando1.Parameters.AddWithValue("@correu", correu1.Text.Trim().ToLower());

            using var reader1 = comando1.ExecuteReader();
            if (reader1.HasRows)
            {
                await DisplayAlert("Error", "Ja existeix un usuari amb aquest correu", "D'acord");
                return;
            }

            reader1.Close();

            // Inserció segura amb hash de contrasenya
            string sql2 = "INSERT INTO login (email, contrasenya, telefon, adreça, nom) VALUES (@correu, @contrasenya, @telefon, @adreca, @nom)";
            MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
            comando2.Parameters.AddWithValue("@correu", correu1.Text.Trim().ToLower());
            comando2.Parameters.AddWithValue("@contrasenya", HashContrasenya(contrasenya.Text));
            comando2.Parameters.AddWithValue("@telefon", telefon.Text.Trim());
            comando2.Parameters.AddWithValue("@adreca", adreça.Text.Trim());
            comando2.Parameters.AddWithValue("@nom", nom.Text.Trim());

            comando2.ExecuteNonQuery();

            await DisplayAlert("Èxit!", "Compte creat correctament!", "D'acord");
            Application.Current.MainPage = new MainPage();
        }
        catch (MySqlException ex)
        {
            await DisplayAlert("Error", "Error MySQL: " + ex.Message, "D'acord");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Error inesperat: " + ex.Message, "D'acord");
        }
        finally
        {
            if (conexionBD != null && conexionBD.State == System.Data.ConnectionState.Open)
                conexionBD.Close();
        }
    }
}
