using MySql.Data.MySqlClient;

namespace Fitxar;

public partial class Configuracio : ContentPage
{
    public Configuracio()
    {
        InitializeComponent();
    }

    // ✔️ Comprova si la nova contrasenya compleix requisits de força (majúscula, número i símbol)
    private void Contrasenya1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Any(char.IsDigit) &&
            e.NewTextValue.Any(c => !char.IsLetterOrDigit(c)) &&
            e.NewTextValue.Any(char.IsUpper))
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

    // ✔️ Comprova si les dues contrasenyes coincideixen
    private void Contrasenya2_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Equals(Contrasenya1.Text))
        {
            val_contrasenya2.Text = "☑";
            val_contrasenya2.TextColor = Colors.Green;
        }
        else
        {
            val_contrasenya2.Text = "X";
            val_contrasenya2.TextColor = Colors.Red;
        }
    }

    // 🔐 Lògica per canviar la contrasenya a la base de dades
    private async void ContrasenyaBtnClicked(object sender, EventArgs e)
    {
        // Comprovació visual de contrasenyes
        if (val_contrasenya1.TextColor != Colors.Green || val_contrasenya2.TextColor != Colors.Green)
        {
            await DisplayAlert("Error", "Comprova les contrasenyes introduïdes", "D'acord!");
            return;
        }

        string novaContrasenya = Contrasenya1.Text.Trim();
        var app = Application.Current as App;
        string email = Preferences.Get("Email", app.Obj.email);

        MySqlConnection conexionBD = null;
        MySqlDataReader reader = null;

        try
        {
            conexionBD = Conexion.conexion();
            conexionBD.Open();

            // Consulta per obtenir la contrasenya actual
            string sqlConsulta = "SELECT contrasenya_treballador FROM treballadors WHERE email_treballador = @email LIMIT 1";
            MySqlCommand cmdConsulta = new MySqlCommand(sqlConsulta, conexionBD);
            cmdConsulta.Parameters.AddWithValue("@email", email);
            reader = cmdConsulta.ExecuteReader();

            string contrasenyaAntiga = "";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    contrasenyaAntiga = reader.GetString("contrasenya_treballador");
                }
            }
            reader.Close();

            // Evita reutilitzar la mateixa contrasenya
            if (contrasenyaAntiga.Equals(novaContrasenya))
            {
                await DisplayAlert("Error", "Introdueix una contrasenya diferent de l'actual", "D'acord!");
                return;
            }

            // Actualització segura de la contrasenya
            string sqlUpdate = "UPDATE treballadors SET contrasenya_treballador = @novaContra WHERE email_treballador = @email";
            MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conexionBD);
            cmdUpdate.Parameters.AddWithValue("@novaContra", novaContrasenya);
            cmdUpdate.Parameters.AddWithValue("@email", email);
            cmdUpdate.ExecuteNonQuery();

            await DisplayAlert("Èxit!", "Contrasenya canviada correctament", "D'acord!");
        }
        catch (MySqlException ex)
        {
            await DisplayAlert("Error de base de dades", ex.Message, "D'acord");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error inesperat", ex.Message, "D'acord");
        }
        finally
        {
            // Tanca connexió de manera segura
            reader?.Close();
            if (conexionBD != null && conexionBD.State == System.Data.ConnectionState.Open)
                conexionBD.Close();
        }
    }
}
