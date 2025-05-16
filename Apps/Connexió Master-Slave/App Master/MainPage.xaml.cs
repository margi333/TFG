using System.Net.Sockets; // Llibreria per treballar amb sockets TCP/IP
using System.Net;

namespace App_Master
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); // Inicialitza els components visuals de la pàgina (XAML)
        }

        // Mètode que s’executa quan l’usuari fa clic al botó de connexió
        private async void OnConnectatClicked(object sender, EventArgs e)
        {
            int port = 27643; // Port TCP pel qual es comunicarà amb el servidor

            // Accedeix a l’instància global de l’aplicació
            var app = Application.Current as App;

            // Inicialitza un socket TCP (IPv4, tipus Stream, protocol TCP)
            app.Obj.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Intenta connectar-se al servidor especificat mitjançant IP i port
                app.Obj.clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.18.103"), port));

                // Si la connexió té èxit, es mostra un missatge i es redirigeix a la SecondaryPage
                await DisplayAlert("Èxit!", "Connectat al PC!", "D'acord");
                Application.Current.MainPage = new SecondaryPage(); // Navega a la pàgina secundària
            }
            catch (Exception ex)
            {
                // Si no es pot connectar, es mostra un missatge d'error
                await DisplayAlert("Error", "No s'ha pogut connectar", "D'acord");
            }
        }
    }
}
