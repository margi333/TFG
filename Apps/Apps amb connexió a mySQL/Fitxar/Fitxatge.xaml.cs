using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Fitxar;
/*COSES A FER:
    PREFERENCES A FITXAR PER A QUE NO PUGI FITXAR MÉS D'UN COP AL DIA
    ARREGLAR ESTÈTICAMENT
    COMPROVAR FUNCIONAMENT DEL CAMBI DE CONTRASENYA
*/
public partial class Fitxatge : ContentPage
{
    public string? Nom { get; set; } = "";

    private bool inici = true;
    public string Dia { get; set; }
    public string Hores { get; set; }
    public Fitxatge()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
        IniciarActualitzacioHora();
        if (inici)
        {
            inici = false;
            Inici_Nom();
        }
    }
    private void IniciarActualitzacioHora()
    {
        // Utilitza el Dispatcher principal
        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            HoraLabel.Text = DateTime.Now.ToString("HH:mm");
        };
        timer.Start();
    }
    private void Inici_Nom()
    {
        MySqlConnection conexionBD = Conexion.conexion();
        conexionBD.Open();
        MySqlDataReader reader2 = null;
        var app = Application.Current as App;
        string sql2 = "SELECT nom_treballador FROM treballadors WHERE email_treballador LIKE '" + Preferences.Get("Email", app.Obj.email) + "' LIMIT 1";
        MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD);
        reader2 = comando2.ExecuteReader();
        string? nom_sql = "";
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                nom_sql = reader2.GetString("nom_treballador");
            }
            app.Obj.nom = nom_sql;
        }
        reader2.Close();
        conexionBD.Close();
        Nom = app.Obj.nom;
    }
    bool fitxar_entrada = false;
    private void FitxarBtnClicked(object sender, EventArgs e)
    {
        if (!fitxar_entrada)
        {
            fitxar_entrada = true;
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            var app = Application.Current as App;
            string tableName = Preferences.Get("DB", null) ;

            // Fes servir interpolació per al nom de la taula
            string sql = $"INSERT INTO {tableName} (dia, hora_entrada) VALUES (@dia, @hora_in);";

            MySqlCommand comando3 = new MySqlCommand(sql, conexionBD);
            comando3.Parameters.AddWithValue("@dia", DateTime.Now.ToString("yyyy-MM-dd"));
            comando3.Parameters.AddWithValue("@hora_in", DateTime.Now.ToString("HH:mm:ss"));
            comando3.ExecuteNonQuery();
            conexionBD.Close();
            EstatFitxatge.Text = $"Has fitxat la entrada a les {DateTime.Now.ToString("HH:mm")}";
        }
        else
        {
            fitxar_entrada = false;
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();
            var app = Application.Current as App;
            string tableName = Preferences.Get("DB", null);

            string sql = $"UPDATE {tableName} SET hora_sortida = @hora_out WHERE dia = @dia LIMIT 1";

            MySqlCommand comando3 = new MySqlCommand(sql, conexionBD);
            comando3.Parameters.AddWithValue("@dia", DateTime.Now.ToString("yyyy-MM-dd"));
            comando3.Parameters.AddWithValue("@hora_out", DateTime.Now.ToString("HH:mm:ss"));
            comando3.ExecuteNonQuery();
            conexionBD.Close();
            EstatFitxatge.Text = $"Has fitxat la sortida a les {DateTime.Now.ToString("HH:mm")}";
        }
    }
}

public class MainViewModel
{
    public ObservableCollection<FitxatgeItem> Fitxades { get; set; }
    string? nom_sql = "";
    string? dia1, dia2, dia3;
    string? horain1, horain2, horain3;
    string? horaout1, horaout2, horaout3;
    public MainViewModel()
    {
        MySqlConnection conexionBD = Conexion.conexion();
        conexionBD.Open();
        MySqlDataReader reader2 = null;
        var app = Application.Current as App;
        string tableName = Preferences.Get("BD", "`bznhpmxi9fccnbiorubm`.`Marc Marginet #1`");
        string sql = $"SELECT * FROM {tableName} ORDER BY dia DESC LIMIT 3;";
        MySqlCommand comando2 = new MySqlCommand(sql, conexionBD);
        reader2 = comando2.ExecuteReader();
        int fila = 0;
        if (reader2.HasRows)
        {
            while (reader2.Read())
            {
                if (fila == 0)
                {
                    dia1 = reader2.GetDateTime("dia").ToString("dd/MM/yyyy");
                    horain1 = reader2.GetTimeSpan("hora_entrada").ToString(@"hh\:mm");
                    horaout1 = reader2.GetTimeSpan("hora_sortida").ToString(@"hh\:mm");
                }
                else if (fila == 1)
                {
                    dia2 = reader2.GetDateTime("dia").ToString("dd/MM/yyyy");
                    horain2 = reader2.GetTimeSpan("hora_entrada").ToString(@"hh\:mm");
                    horaout2 = reader2.GetTimeSpan("hora_sortida").ToString(@"hh\:mm");
                }
                else if (fila == 2)
                {
                    dia3 = reader2.GetDateTime("dia").ToString("dd/MM/yyyy");
                    horain3 = reader2.GetTimeSpan("hora_entrada").ToString(@"hh\:mm");
                    horaout3 = reader2.GetTimeSpan("hora_sortida").ToString(@"hh\:mm");
                }

                fila++;
            }
        }
        reader2.Close();
        conexionBD.Close();
        Fitxades = new ObservableCollection<FitxatgeItem>
        {
            new FitxatgeItem { Dia = dia1, Hores = $"{horain1} – {horaout1}" },
            new FitxatgeItem { Dia = dia2, Hores = $"{horain2} – {horaout2}" },
            new FitxatgeItem { Dia = dia3, Hores = $"{horain3} – {horaout3}" }
        };
    }
}
public class FitxatgeItem
{
    public string Dia { get; set; }
    public string Hores { get; set; }
}