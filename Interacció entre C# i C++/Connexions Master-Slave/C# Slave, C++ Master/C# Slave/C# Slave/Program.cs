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
        listenSocket.Bind(new IPEndPoint(IPAddress.Parse("192.168.68.105"), port));
        listenSocket.Listen(10); // Permet fins a 10 connexions en cua

        Console.WriteLine("Servidor escoltant al port " + port + "...");

        while (true)
        {
            Console.WriteLine("Esperant connexions...");
            Socket clientSocket = listenSocket.Accept(); // Accepta la connexió entrant
            Console.WriteLine("Client connectat!");

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
        while (clientSocket != null && clientSocket.Connected)
        {
            byte[] buffer = new byte[sizeof(int) * 3];
            int bytesRead = clientSocket.Receive(buffer);
            if(bytesRead == 0)
            {
                Console.WriteLine("Tancant connexio...");
                break;
            }
            if (bytesRead > 0)
            {
                bytesRead = 0;
                int num1 = BitConverter.ToInt32(buffer, 0);
                int num2 = BitConverter.ToInt32(buffer, sizeof(int));
                int num3 = BitConverter.ToInt32(buffer, sizeof(int)*2);

                switch(num3)
                {
                    case 1:
                        Console.WriteLine($" Els numeros rebuts son: {num1}, {num2}. La suma equival a {num1 + num2}");
                        break;
                    case 2:
                        Console.WriteLine($" Els numeros rebuts son: {num1}, {num2}. La resta equival a {num1 - num2}");
                        break;
                }

                // Enviar ACK (confirmació)
                byte[] ack = { 0x06 };  // 0x06 = ACK
                clientSocket.Send(ack);
            }
        }
        clientSocket.Close();
        Console.WriteLine("Connexió tancada");
    }
}
