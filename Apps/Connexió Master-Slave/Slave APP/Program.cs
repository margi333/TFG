using System.Net;
using System.Net.Sockets;
using Slave_APP;

class Program
{
    static void Main()
    {
        int port = 27643;
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Assigna la IP i el port al socket
        listenSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.18.103"), port));
        listenSocket.Listen(1); // Permet fins a 1 connexió en cua

        Console.WriteLine("Servidor escoltant al port " + port + "...");

        while (true)
        {
            Console.WriteLine("Esperant connexions...");
            Socket clientSocket = listenSocket.Accept();
            Console.WriteLine("Client connectat!");

            // Gestiona el client en una altra classe
            var clientHandler = new ClientHandler(clientSocket);
            clientHandler.HandleClient();
        }

    }
}
