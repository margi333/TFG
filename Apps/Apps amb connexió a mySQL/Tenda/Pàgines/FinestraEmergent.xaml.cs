using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace Tenda
{
    using Microsoft.Maui.Controls;
    using Tenda.Pàgines;

    // Component reutilitzable de finestra emergent per fer reserves de productes
    public partial class FinestraEmergent : ContentView
    {
        // Esdeveniment per mostrar alertes des del component pare
        public event EventHandler<string> OnShowAlertRequested;

        // Propietats bindables (permeten data binding des del XAML o codi)
        public static readonly BindableProperty Nom_ElementProperty =
           BindableProperty.Create(nameof(Nom_Element), typeof(string), typeof(FinestraEmergent), string.Empty, BindingMode.TwoWay, propertyChanged: OnNomElementChanged);

        public static readonly BindableProperty Nom_ImatgeProperty =
          BindableProperty.Create(nameof(Nom_Imatge), typeof(string), typeof(FinestraEmergent), string.Empty, BindingMode.TwoWay, propertyChanged: OnNomImatgeChanged);

        public static readonly BindableProperty Color1Property =
         BindableProperty.Create(nameof(Color1), typeof(string), typeof(FinestraEmergent), string.Empty);

        public static readonly BindableProperty Color2Property =
         BindableProperty.Create(nameof(Color2), typeof(string), typeof(FinestraEmergent), string.Empty);

        public static readonly BindableProperty Color3Property =
         BindableProperty.Create(nameof(Color3), typeof(string), typeof(FinestraEmergent), string.Empty);

        // Propietats amb suport per INotifyPropertyChanged (avisar quan canvien)
        private string _nom_Element = string.Empty;
        public string Nom_Element
        {
            get => _nom_Element;
            set
            {
                if (_nom_Element != value)
                {
                    _nom_Element = value;
                    OnPropertyChanged(nameof(Nom_Element));
                }
            }
        }

        private string _nom_Imatge = string.Empty;
        public string Nom_Imatge
        {
            get => _nom_Imatge;
            set
            {
                if (_nom_Imatge != value)
                {
                    _nom_Imatge = value;
                    OnPropertyChanged(nameof(Nom_Imatge));
                }
            }
        }

        // Colors disponibles per seleccionar
        public string? Color1 { get; set; } = null;
        public string? Color2 { get; set; } = null;
        public string? Color3 { get; set; } = null;

        // Llista observable per a la UI
        public ObservableCollection<string> ColorsList { get; set; }

        public FinestraEmergent()
        {
            InitializeComponent();
            BindingContext = this; // Estableix aquesta classe com a context de dades
        }

        // Actualitza la llista de colors disponibles en temps real
        public void ActualitzaColors()
        {
            ColorsList = new ObservableCollection<string>
            {
                Color1,
                Color2,
                Color3
            };
            OnPropertyChanged(nameof(ColorsList));
        }

        // Tanca la finestra emergent
        private void TancarFinestra(object sender, EventArgs e)
        {
            this.IsVisible = false;
        }

        // Quan canvia el nom de l’article, actualitza la propietat
        private static void OnNomElementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as FinestraEmergent;
            control?.OnPropertyChanged(nameof(Nom_Element));
        }

        // Quan canvia la imatge, actualitza la propietat
        private static void OnNomImatgeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as FinestraEmergent;
            control?.OnPropertyChanged(nameof(Nom_Imatge));
        }

        // 🔐 Envia la comanda a la base de dades quan es fa clic a "Reservar"
        private async void ReservarBtnClicked(object sender, EventArgs e)
        {
            this.IsVisible = false; // Amaga la finestra després de fer clic
            var app = Application.Current as App;

            // SQL amb paràmetres per evitar injecció
            string sql = "INSERT INTO comandes (article, color, quantitat, talla, email) VALUES (@article, @color, @quantitat, @talla, @email)";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.Parameters.AddWithValue("@article", Nom_Element);
                comando.Parameters.AddWithValue("@color", color.SelectedItem?.ToString() ?? "");
                comando.Parameters.AddWithValue("@quantitat", Quantitat.SelectedItem?.ToString() ?? "");
                comando.Parameters.AddWithValue("@talla", Talla.SelectedItem?.ToString() ?? "");
                comando.Parameters.AddWithValue("@email", app.Info.email);

                comando.ExecuteNonQuery();

                // Mostra notificació d’èxit i redirigeix
                await app.MainPage.DisplayAlert("Èxit!", "Comanda feta correctament", "Acceptar");
                Application.Current.MainPage = new AppShell();
            }
            catch (MySqlException ex)
            {
                await app.MainPage.DisplayAlert("Error", ex.Message, "Acceptar");
            }
            finally
            {
                conexionBD.Close(); // Tanca la connexió sempre
            }
        }
    }
}
