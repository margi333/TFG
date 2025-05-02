using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            int port = 27643;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Assigna la IP i el port al socket
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.18.179"), port));
            Console.WriteLine("Connectat al servidor!");

            while (true)
            {
                Console.WriteLine("Introdueix un numero");
                bool num_correcte = false;
                int num1 = 0, num2 = 0;
                do
                {
                    string? n1 = Console.ReadLine();
                    try
                    {
                        if (n1 == "")
                        {
                            clientSocket.Close();
                            Console.WriteLine("Connexió tancada.");
                            return;
                        }
                        num1 = int.Parse(n1);
                        num_correcte = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                } while (!num_correcte);

                Console.WriteLine("Introdueix un segon numero");
                num_correcte = false;
                do
                {
                    string? n2 = Console.ReadLine();
                    try
                    {
                        if (n2 == "")
                        {
                            clientSocket.Close();
                            Console.WriteLine("Connexió tancada.");
                            return;
                        }
                        num2 = int.Parse(n2);
                        num_correcte = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                } while (!num_correcte);
                Console.WriteLine("Introdueix el si vols una Suma(1) o una Resta (2)");
                num_correcte = false;
                int operacio = 0;
                do
                {
                    string? n3 = Console.ReadLine();
                    try
                    {
                        if (n3 == "")
                        {
                            clientSocket.Close();
                            Console.WriteLine("Connexió tancada.");
                            return;
                        }
                        operacio = int.Parse(n3);
                        if (operacio != 1 && operacio != 2)
                        {
                            Console.WriteLine("Introdueix un numero correcte");
                        }
                        else
                        {
                            num_correcte = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                } while (!num_correcte);

                byte[] buffer = new byte[sizeof(int) * 3];
                Buffer.BlockCopy(BitConverter.GetBytes(num1), 0, buffer, 0, sizeof(int));
                Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, buffer, sizeof(int), sizeof(int));
                Buffer.BlockCopy(BitConverter.GetBytes(operacio), 0, buffer, sizeof(int) * 2, sizeof(int));

                clientSocket.Send(buffer);
                Console.WriteLine("Dades enviades al servidor!");

                byte[] ackBuffer = new byte[1];
                int bytesRead = clientSocket.Receive(ackBuffer);

                if (bytesRead > 0 && ackBuffer[0] == 0x06) // 0x06 és ACK
                {
                    Console.WriteLine("Resposta rebuda: Operacio confirmada per servidor.");
                }
                else
                {
                    Console.WriteLine("Error en la resposta del servidor.");
                }
            }
        }
        catch( Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    }
}
