using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fitxar;

public partial class Fitxatge : ContentPage
{
    string? Nom;
    private bool inici = true;
    public string Dia { get; set; }
    public string Hores { get; set; }

    public Fitxatge()
    {
        InitializeComponent();
        BindingContext = new MainViewModel(); // S'estableix el context de dades a la classe MainViewModel
        IniciarActualitzacioHora(); // S'inicia el temporitzador que actualitza l'hora actual
    }

    // M�tode que estableix un temporitzador per actualitzar l'hora cada segon
    private void IniciarActualitzacioHora()
    {
        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            HoraLabel.Text = DateTime.Now.ToString("HH:mm");

            // Aquest fragment comprova si el temps �s zero i estableix una prefer�ncia
            if (DateTime.Now.Equals(TimeSpan.Zero))
            {
                Preferences.Set("fitxar", true);
            }
        };
        timer.Start();
    }

    bool fitxar_entrada = false;

    // M�tode que s�executa quan l�usuari fa clic per fitxar entrada o sortida
    private void FitxarBtnClicked(object sender, EventArgs e)
    {
        if (Preferences.Get("fitxar", true))
        {
            if (!fitxar_entrada)
            {
                // Si encara no s�ha fitxat l�entrada, es registra la fitxada d�entrada
                fitxar_entrada = true;
                MySqlConnection conexionBD = Conexion.conexion();
                conexionBD.Open();
                var app = Application.Current as App;
                string tableName = Preferences.Get("DB", null);

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
                // Si ja s�ha fitxat l�entrada, ara es registra la sortida
                fitxar_entrada = false;
                Preferences.Set("fitxar", false);
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
}

// Classe que implementa el patr� ViewModel per mantenir les dades sincronitzades amb la vista
public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<FitxatgeItem> Fitxades { get; set; } = new();

    private string? nom;
    public string? Nom
    {
        get => nom;
        set
        {
            if (nom != value)
            {
                nom = value;
                OnPropertyChanged();
            }
        }
    }

    // Constructor que inicia la c�rrega de dades de l�usuari i fitxatges
    public MainViewModel()
    {
        CarregarDadesAsync();
    }

    private async Task CarregarDadesAsync()
    {
        await CarregarNomAsync();
        await CarregarFitxadesAsync();
    }

    // Carrega el nom del treballador a partir de l'email desat a les prefer�ncies
    private async Task CarregarNomAsync()
    {
        MySqlConnection conexionBD = Conexion.conexion();
        await conexionBD.OpenAsync();
        var app = Application.Current as App;
        string sql = $"SELECT nom_treballador FROM treballadors WHERE email_treballador LIKE '{Preferences.Get("Email", app.Obj.email)}' LIMIT 1";
        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
        using var reader = (MySqlDataReader)await comando.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            Nom = reader.GetString("nom_treballador");
            app.Obj.nom = Nom; // S�actualitza tamb� l�objecte global
        }
        await reader.CloseAsync();
        await conexionBD.CloseAsync();
    }

    // Carrega les tres �ltimes fitxades de l�usuari
    private async Task CarregarFitxadesAsync()
    {
        MySqlConnection conexionBD = Conexion.conexion();
        await conexionBD.OpenAsync();
        var app = Application.Current as App;
        string tableName = Preferences.Get("BD", "`bznhpmxi9fccnbiorubm`.`Marc Marginet #1`");
        string sql = $"SELECT * FROM {tableName} ORDER BY dia DESC LIMIT 3;";
        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
        using var reader = (MySqlDataReader)await comando.ExecuteReaderAsync();
        int fila = 0;
        while (await reader.ReadAsync())
        {
            string dia = reader.GetDateTime("dia").ToString("dd/MM/yyyy");
            string horaEntrada = reader.GetTimeSpan("hora_entrada").ToString(@"hh\:mm");
            string horaSortida = reader.GetTimeSpan("hora_sortida").ToString(@"hh\:mm");
            Fitxades.Add(new FitxatgeItem
            {
                Dia = dia,
                Hores = $"{horaEntrada} � {horaSortida}"
            });
            fila++;
        }
        await reader.CloseAsync();
        await conexionBD.CloseAsync();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

// Classe que representa cada entrada de fitxatge (model de dades)
public class FitxatgeItem
{
    public string Dia { get; set; }
    public string Hores { get; set; }
}
