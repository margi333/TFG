using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

// Classe principal del programa client
class Program
{
    static void Main()
    {
        try
        {
            // Especificació del port de connexió al servidor
            int port = 27643;

            // Creació del socket client amb configuració TCP/IP
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connecta el socket a la IP i port del servidor
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.18.179"), port));
            Console.WriteLine("Connectat al servidor!");

            // Bucle principal per enviar operacions de manera contínua
            while (true)
            {
                Console.WriteLine("Introdueix un numero");
                bool num_correcte = false;
                int num1 = 0, num2 = 0;

                // Validació del primer número
                do
                {
                    string? n1 = Console.ReadLine();
                    try
                    {
                        if (n1 == "") // Si l'usuari no escriu res, es tanca la connexió
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
                        Console.WriteLine("Error: " + ex.Message); // Missatge si el format no és vàlid
                    }

                } while (!num_correcte);

                // Validació del segon número
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

                // Entrada de l’operació a realitzar: 1 per suma, 2 per resta
                Console.WriteLine("Introdueix si vols una Suma (1) o una Resta (2)");
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

                        // Només s’accepten les operacions 1 (suma) i 2 (resta)
                        if (operacio != 1 && operacio != 2)
                        {
                            Console.WriteLine("Introdueix un número correcte");
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

                // Construcció del buffer de dades (3 enters)
                byte[] buffer = new byte[sizeof(int) * 3];
                Buffer.BlockCopy(BitConverter.GetBytes(num1), 0, buffer, 0, sizeof(int));
                Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, buffer, sizeof(int), sizeof(int));
                Buffer.BlockCopy(BitConverter.GetBytes(operacio), 0, buffer, sizeof(int) * 2, sizeof(int));

                // Enviament de les dades al servidor
                clientSocket.Send(buffer);
                Console.WriteLine("Dades enviades al servidor!");

                // Recepció del codi de confirmació (ACK)
                byte[] ackBuffer = new byte[1];
                int bytesRead = clientSocket.Receive(ackBuffer);

                // Comprovació si la resposta és l’ACK (0x06)
                if (bytesRead > 0 && ackBuffer[0] == 0x06)
                {
                    Console.WriteLine("Resposta rebuda: Operació confirmada per servidor.");
                }
                else
                {
                    Console.WriteLine("Error en la resposta del servidor.");
                }
            }
        }
        // Captura qualsevol error de connexió o execució
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
