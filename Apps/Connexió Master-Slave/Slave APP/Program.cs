using System.Net;
using System.Net.Sockets;
using Slave_APP; // Espai de noms on es troba la classe ClientHandler

class Program
{
    static void Main()
    {
        int port = 27643; // Port pel qual el servidor escoltarà connexions entrants

        // Crea un socket TCP per escoltar (IPv4, mode Stream, protocol TCP)
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Associa el socket a una IP i port determinats 
        listenSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.18.103"), port));

        // Comença a escoltar connexions entrants (1 connexió com a màxim en cua)
        listenSocket.Listen(1);

        Console.WriteLine("Servidor escoltant al port " + port + "...");

        // Bucle infinit per acceptar connexions contínuament
        while (true)
        {
            Console.WriteLine("Esperant connexions...");

            // Accepta una connexió entrant (bloquejant fins que un client es connecti)
            Socket clientSocket = listenSocket.Accept();
            Console.WriteLine("Client connectat!");

            // Crea una instància de ClientHandler per gestionar la comunicació amb el client
            var clientHandler = new ClientHandler(clientSocket);

            // Crida el mètode que s’encarrega de tractar les comandes del client
            clientHandler.HandleClient();

            // Quan la gestió del client finalitza, el bucle torna a esperar un nou client
        }
    }
}
