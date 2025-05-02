using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave_APP
{
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
                string ultimaparaula = "";
                int bytesRead = clientSocket.Receive(buffer);
                string decodedString = System.Text.Encoding.ASCII.GetString(buffer);
                if (bytesRead == 0)
                {
                    Console.WriteLine("Tancant connexio...");
                    break;
                }
                if (bytesRead > 0)
                {
                    if (decodedString.Equals("Desconnectar"))
                    {
                        // Enviar ACK (confirmació)
                        byte[] ack = { 0x06 };  // 0x06 = ACK
                        clientSocket.Send(ack);
                        clientSocket.Close();
                    }
                    else
                    {
                        if(decodedString.Equals("Sol·licitar"))
                        {
                            byte[] trama = System.Text.Encoding.ASCII.GetBytes(ultimaparaula);
                            clientSocket.Send(buffer);
                            byte[] ackBuffer = new byte[1];
                            int bRead = clientSocket.Receive(ackBuffer);
                            if (bRead > 0 && ackBuffer[0] == 0x06) // 0x06 és ACK
                            {
                                Console.WriteLine("Última paraula enviada al master");
                            }
                            else
                            {
                                Console.WriteLine("El servidor no respon");
                            }
                        }
                        else
                        {
                            ultimaparaula = decodedString;
                            Console.WriteLine(decodedString);
                            byte[] ack = { 0x06 };  // 0x06 = ACK
                            clientSocket.Send(ack);
                        }
                    }
                }
            }
            clientSocket.Close();
            Console.WriteLine("Connexió tancada");
        }
    }

}
