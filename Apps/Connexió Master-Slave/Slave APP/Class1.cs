using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Slave_APP
{
    // Classe encarregada de gestionar un client connectat a través d’un socket
    class ClientHandler
    {
        private Socket clientSocket; // Socket associat al client
        string ultimaparaula = ""; // Guarda l’últim text rebut per retornar-lo en cas de petició

        // Constructor que rep el socket del client
        public ClientHandler(Socket socket)
        {
            this.clientSocket = socket;
        }

        // Mètode principal que manté la connexió i gestiona els missatges entrants
        public void HandleClient()
        {
            // Bucle principal mentre la connexió estigui activa
            while (clientSocket != null && clientSocket.Connected)
            {
                byte[] buffer = new byte[sizeof(int) * 3]; // Buffer per rebre dades (ex: trama de 3 enters)

                int bytesRead = clientSocket.Receive(buffer); // Llegeix dades del client

                // Converteix el contingut rebut a una cadena (ASCII)
                string decodedString = Encoding.ASCII.GetString(buffer);

                // Si no s’ha rebut cap byte, es considera que el client ha tancat la connexió
                if (bytesRead == 0)
                {
                    Console.WriteLine("Tancant connexió...");
                    break;
                }

                // Si s’han rebut dades...
                if (bytesRead > 0)
                {
                    // --- Comanda de desconnexió ---
                    if (decodedString.Equals("Desconnectar"))
                    {
                        // Envia ACK (confirmació)
                        byte[] ack = { 0x06 }; // 0x06 = ACK
                        clientSocket.Send(ack);
                        clientSocket.Close(); // Tanca la connexió amb el client
                    }
                    // --- Comanda de sol·licitud de dades ---
                    else if (decodedString.Trim().Equals("Solicitar\0\0\0"))
                    {
                        byte[] ack = { 0x06 }; // 0x06 = ACK
                        clientSocket.Send(ack);
                        // Codifica l’última paraula rebuda en ASCII i l’envia com a "trama"
                        byte[] trama = Encoding.ASCII.GetBytes(ultimaparaula);
                        clientSocket.Send(trama); // Envia buffer original (probablement erroni, s'hauria d'enviar 'trama')

                        // Espera ACK per confirmar recepció
                        byte[] ackBuffer = new byte[1];
                        int bRead = clientSocket.Receive(ackBuffer);

                        if (bRead > 0 && ackBuffer[0] == 0x06)
                        {
                            Console.WriteLine("Última paraula enviada al master");
                        }
                        else
                        {
                            Console.WriteLine("El servidor no respon");
                        }
                    }
                    // --- Qualsevol altre missatge és tractat com a "última paraula" ---
                    else
                    {
                        ultimaparaula = decodedString; // Desa la paraula
                        Console.WriteLine(decodedString); // Mostra-la per consola
                        byte[] ack = { 0x06 }; // Envia ACK
                        clientSocket.Send(ack);
                    }
                }
            }

            // Quan es surt del bucle, es tanca la connexió definitivament
            clientSocket.Close();
            Console.WriteLine("Connexió tancada");
        }
    }
}

