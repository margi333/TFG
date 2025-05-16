// Fitxer: SecondaryPage.xaml.cs
// Aquesta classe representa una p�gina de l�aplicaci� .NET MAUI que es comunica amb un servidor via sockets TCP.

using System;
using App_Master;

public partial class SecondaryPage : ContentPage
{
    public SecondaryPage()
    {
        InitializeComponent(); // Inicialitza els components visuals (definits a XAML)
    }

    // M�tode per enviar text lliure al servidor
    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        // Converteix el contingut del TextBox a ASCII i ho guarda en un buffer
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes(TextEnviar.Text);

        try
        {
            // Accedeix a l'objecte global que cont� el socket
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer); // Envia les dades

            // Prepara un buffer per rebre l�ACK
            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06) // 0x06 = ACK
            {
                await DisplayAlert("�xit!", "Text enviat!", "D'acord");
            }
            else
            {
                await DisplayAlert("Error", "El servidor no respon", "D'acord");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "D'acord");
        }
    }

    // M�tode per desconnectar-se del servidor
    private async void OnDesconnectarClicked(object sender, EventArgs e)
    {
        // Missatge de desconnexi�
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("Desconnectar");

        try
        {
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer);

            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06)
            {
                await DisplayAlert("�xit!", "Desconnectat de l'esclau", "D'acord");
            }
            else
            {
                await DisplayAlert("Error", "El servidor no respon", "D'acord");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "D'acord");
        }
    }

    // M�tode per reclamar una resposta estructurada del servidor (ex: 2 n�meros + operaci�)
    private async void OnReclamarClicked(object sender, EventArgs e)
    {
        // Missatge per iniciar la sol�licitud
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("Sol�licitar");

        try
        {
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer);

            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06)
            {
                // Buffer per rebre la "trama" (3 enters = 12 bytes)
                byte[] trama = new byte[sizeof(int) * 3];
                int tramaRead = app.Obj.clientSocket.Receive(trama);

                if (tramaRead >= 12)
                {
                    // Converteix els bytes rebuts a enters
                    int num1 = BitConverter.ToInt32(trama, 0);
                    int num2 = BitConverter.ToInt32(trama, 4);
                    int operacio = BitConverter.ToInt32(trama, 8);

                    // Mostra la informaci� rebuda
                    await DisplayAlert("Dades rebudes",
                        $"Primer n�mero: {num1}\nSegon n�mero: {num2}\nCodi operaci�: {operacio}",
                        "D'acord");

                    // Envia ACK per confirmar la recepci�
                    byte[] ack = { 0x06 };
                    app.Obj.clientSocket.Send(ack);
                }
                else
                {
                    await DisplayAlert("Error", "La trama rebuda �s incompleta", "D'acord");
                }
            }
            else
            {
                await DisplayAlert("Error", "El servidor no respon", "D'acord");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "D'acord");
        }
    }
}
