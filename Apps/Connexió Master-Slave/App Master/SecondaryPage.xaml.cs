using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace App_Master;


public partial class SecondaryPage : ContentPage
{
	public SecondaryPage()
	{
		InitializeComponent();
	}
	private async void OnEnviarClicked(object sender, EventArgs e)
	{
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes(TextEnviar.Text);
        try
        {
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer);
            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06) // 0x06 �s ACK
            {
                await DisplayAlert("�xit!", "Text enviat!", "D'acord");
            }
            else
            {
                await DisplayAlert("Error", "El servidor no respon", "D'acord");
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "D'acord");
        }
    }
    private async void OnDesconnectarClicked(object sender, EventArgs e)
    {
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("Desconnectar");
        try
        {
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer);
            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06) // 0x06 �s ACK
            {
                await DisplayAlert("�xit!", "Desconnectat del esclau", "D'acord");
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
    private async void OnReclamarClicked(object sender, EventArgs e)
    {
        byte[] buffer = System.Text.Encoding.ASCII.GetBytes("Solicitar");
        try
        {
            var app = Application.Current as App;
            app.Obj.clientSocket.Send(buffer);
            byte[] ackBuffer = new byte[1];
            int bytesRead = app.Obj.clientSocket.Receive(ackBuffer);

            if (bytesRead > 0 && ackBuffer[0] == 0x06) // 0x06 �s ACK
            {
                byte[]? trama = new byte[sizeof(int) * 3];
                int tramaRead = app.Obj.clientSocket.Receive(trama);
                if (bytesRead > 0)
                {
                    await DisplayAlert("�xit!", Encoding.ASCII.GetString(trama), "D'acord");
                    // Enviar ACK (confirmaci�)
                    byte[] ack = { 0x06 };  // 0x06 = ACK
                    app.Obj.clientSocket.Send(ack);
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