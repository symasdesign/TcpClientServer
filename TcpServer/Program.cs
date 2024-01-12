namespace TcpServer {
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class TcpServer {
        private const int Port = 8000;

        static void Main() {
            var listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();

            Console.WriteLine("Server gestartet und wartet auf Verbindungen...");

            while (true) {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Verbindung akzeptiert.");

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);

                string request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine($"Empfangen: {request}");

                string response = $"Hallo Client, deine Nachricht wurde empfangen: {request}";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);

                client.Close();
            }
        }
    }
}
