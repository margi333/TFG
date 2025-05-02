using System.Net.Sockets;
using System.Net;

namespace App_Master
{
    using System.Net;
    using System.Net.Sockets;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnConnectatClicked(object sender, EventArgs e)
        {
            int port = 27643;
            var app = Application.Current as App;
            app.Obj.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Assigna la IP i el port al socket
                app.Obj.clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.18.103"), port));
                await DisplayAlert("Éxit!", "Connectat al PC!", "D'acord");
                Application.Current.MainPage = new SecondaryPage();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "No s'ha pogut connectar", "D'acord");
            }
        }
    }

}
