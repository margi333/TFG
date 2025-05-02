using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;

namespace Tenda
{
    using Microsoft.Maui.Controls;
    using Tenda.Pàgines;

    public partial class FinestraEmergent : ContentView
    {
        public event EventHandler<string> OnShowAlertRequested;

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
        private string _nom_Element = string.Empty;
        public string Nom_Element
        {
            get => _nom_Element;
            set
            {
                if (_nom_Element != value)
                {
                    _nom_Element = value;
                    OnPropertyChanged(nameof(Nom_Element)); // Notificar el canvi
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
                    OnPropertyChanged(nameof(Nom_Imatge)); // Notificar el canvi
                }
            }
        }
        public string? Color1 { get; set; } = null;
        public string? Color2 { get; set; } = null;
        public string? Color3 { get; set; } = null;
        public ObservableCollection<string> ColorsList { get; set; }

        public FinestraEmergent()
        {
            InitializeComponent();
            BindingContext = this;
        }

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
        private void TancarFinestra(object sender, EventArgs e)
        {
            this.IsVisible = false;
        }

        private static void OnNomElementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as FinestraEmergent;
            control?.OnPropertyChanged(nameof(Nom_Element));
        }

        private static void OnNomImatgeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as FinestraEmergent;
            control?.OnPropertyChanged(nameof(Nom_Imatge));
        }

        private async void ReservarBtnClicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            var app = Application.Current as App;
            string sql = "INSERT INTO comandes (article,color, quantitat, talla, email) VALUES ( '" + Nom_Element + "', '" + color.SelectedItem.ToString() + "', '" + Quantitat.SelectedItem.ToString() + "', '" + Talla.SelectedItem.ToString() + "', '" + app.Info.email + "')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                app.MainPage.DisplayAlert("Éxit!", "Comanda feta correctament", "Acceptar");
                conexionBD.Close();
                Application.Current.MainPage = new AppShell();
            }
            catch (MySqlException ex)
            {
                app.MainPage.DisplayAlert("Error", ex.Message, "Acceptar");
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}
