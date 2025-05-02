using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        int port = 27643;
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Assigna la IP i el port al socket
        listenSocket.Bind(new IPEndPoint(IPAddress.Any, port));
        listenSocket.Listen(10); // Permet fins a 10 connexions en cua

        Console.WriteLine("Servidor escoltant al port " + port + "...");

        while (true)
        {
            Console.WriteLine("Esperant connexions...");
            Socket clientSocket = listenSocket.Accept(); // Accepta la connexió entrant
            Console.WriteLine("✅ Client connectat!");

            // Gestiona el client en una altra classe
            var clientHandler = new ClientHandler(clientSocket);
            clientHandler.HandleClient();
        }
    }
}

// Classe per gestionar cada client
class ClientHandler
{
    private Socket clientSocket;

    public ClientHandler(Socket socket)
    {
        this.clientSocket = socket;
    }

    public void HandleClient()
    {
        byte[] buffer = new byte[512];
        int bytesRead = clientSocket.Receive(buffer);

        if (bytesRead > 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("📩 Missatge rebut: " + message);

            // Enviar ACK (confirmació)
            byte[] ack = { 0x06 };  // 0x06 = ACK
            clientSocket.Send(ack);
        }

        clientSocket.Close(); // Tanca la connexió
    }
}
