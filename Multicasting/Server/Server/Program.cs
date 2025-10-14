using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class UdpServer
{
    static Dictionary<string, IPEndPoint> clients = new Dictionary<string, IPEndPoint>();
    static Dictionary<string, FinancialData> tradingData = new Dictionary<string, FinancialData>();
    static UdpClient udpServer;

    static void Main()
    {
        udpServer = new UdpClient(5505);
        Console.WriteLine("UDP Server started on port 5505...");

        Thread dataUpdateThread = new Thread(UpdateTradingData);
        dataUpdateThread.Start();

        while (true)
        {
            ReceiveClientData();
        }
    }

    static void ReceiveClientData()
    {
        IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);
        byte[] buffer = udpServer.Receive(ref clientEP);

        string clientMessage = Encoding.ASCII.GetString(buffer).Trim();
        Console.WriteLine($"Received data from {clientEP}: {clientMessage}");

        if (clientMessage.StartsWith("ID:"))
        {
            string userId = clientMessage.Substring(3).Trim();
            lock (clients)
            {
                if (!clients.ContainsKey(userId))
                {
                    clients[userId] = clientEP;
                    Console.WriteLine($"Client registered with User ID: {userId}");
                }
            }
            SendInitialData(clientEP);
        }
        else
        {
            // Process other types of client messages if necessary
        }
    }

    static void SendInitialData(IPEndPoint clientEP)
    {
        string initialData = SerializeTradingData();
        byte[] data = Encoding.ASCII.GetBytes(initialData);
        udpServer.Send(data, data.Length, clientEP);
    }

    static void UpdateTradingData()
    {
        Random rand = new Random();
        while (true)
        {
            lock (tradingData)
            {
                foreach (var key in tradingData.Keys.ToList())
                {
                    var financialData = tradingData[key];

                    // Random updates for demonstration purposes. Replace with actual logic as needed.
                    financialData.SpanMargin = (decimal)(rand.NextDouble() * 10000);
                    financialData.ExposureMargin = (decimal)(rand.NextDouble() * 5000);
                    financialData.TotalMargin = (decimal)(rand.NextDouble() * 15000);
                    financialData.PeakMargin = (decimal)(rand.NextDouble() * 20000);
                    financialData.Exposure = (decimal)(rand.NextDouble() * 1000000);
                    financialData.VarTotal = (decimal)(rand.NextDouble() * 50000);
                    financialData.PeakVar = (decimal)(rand.NextDouble() * 30000);
                    financialData.TodaysDelivery = (decimal)(rand.NextDouble() * 1000);
                    financialData.TotalDelivery = (decimal)(rand.NextDouble() * 5000);
                    financialData.PeakDeliv = (decimal)(rand.NextDouble() * 10000);
                    financialData.OPTRealDay = (decimal)(rand.NextDouble() * 500);
                    financialData.OPTUnrealDay = (decimal)(rand.NextDouble() * 700);
                    financialData.OPTMTMNet = (decimal)(rand.NextDouble() * 1000);
                    financialData.OPTMTMDay = (decimal)(rand.NextDouble() * 1500);
                    financialData.FUTRealDay = (decimal)(rand.NextDouble() * 200);
                    financialData.FUTUnrealDay = (decimal)(rand.NextDouble() * 300);
                    financialData.FUTMTMNet = (decimal)(rand.NextDouble() * 600);
                    financialData.FUTMTMDay = (decimal)(rand.NextDouble() * 800);
                    financialData.AllotedFund = (decimal)(rand.NextDouble() * 100000);
                    financialData.UtilizedPercentage = rand.NextDouble() * 100;
                    financialData.ExposureMargin2 = (decimal)(rand.NextDouble() * 5000);
                }
            }
            BroadcastUpdatedData();
            Thread.Sleep(1000); // Update every second
        }
    }


    static void BroadcastUpdatedData()
    {
        string updatedData = SerializeTradingData();
        byte[] data = Encoding.ASCII.GetBytes(updatedData);

        lock (clients)
        {
            foreach (var clientEP in clients.Values)
            {
                try
                {
                    udpServer.Send(data, data.Length, clientEP);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending to client {clientEP}: {ex.Message}");
                }
            }
        }
    }

    static string SerializeTradingData()
    {
        lock (tradingData)
        {
            var sb = new StringBuilder();
            foreach (var item in tradingData)
            {
                sb.AppendLine($"{item.Key}:{item.Value:F2}");
            }
            return sb.ToString();
        }
    }
}
