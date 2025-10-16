using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class UdpClientExample
{
    static UdpClient udpClient;
    static IPEndPoint serverEP;

    static void Main()
    {
        string userId = "Umeshpal12"; // Replace with actual unique user ID
        udpClient = new UdpClient();
        serverEP = new IPEndPoint(IPAddress.Any, 5505); // Replace with the server's IP and port telnet 122.176.109.148 8002

        SendUserId(userId);

        Thread readThread = new Thread(ReadMessages);
        readThread.Start();

        // Keep the application running to listen for updates
        Console.ReadLine();
    }

    static void SendUserId(string userId)
    {
        string message = $"ID:{userId}";
        byte[] data = Encoding.ASCII.GetBytes(message);
        udpClient.Send(data, data.Length, serverEP);
    }

    static void ReadMessages()
    {
        IPEndPoint receivedEP = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            try
            {
                byte[] buffer = udpClient.Receive(ref receivedEP);
                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine($"Received data:\n{message}");
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"SocketException: {ex.Message}");
                // Optionally, you can decide how to handle the exception, e.g., retry, log, or alert.
                Thread.Sleep(1000); // Sleep for a while before retrying
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                // Handle unexpected errors gracefully
            }
        }
    }

}
