namespace TcpClient {
    using System;
    using System.Net.Sockets;
    using System.Text;

    class TcpClientProgram {
        private const string ServerIp = "127.0.0.1"; // Oder die IP-Adresse des Servers, wenn er sich auf einem anderen Gerät befindet
        private const int Port = 8000;

        static void Main(string[] args) {
            var ip = args.Length > 0 ? args[0] : ServerIp;
            using (var client = new TcpClient(ip, Port)) {
                Console.WriteLine("Mit dem Server verbunden.");

                NetworkStream stream = client.GetStream();

                Console.Write("Nachricht eingeben: ");

                string message = Console.ReadLine(); 
                byte[] data = Encoding.UTF8.GetBytes(message);

                stream.Write(data, 0, data.Length);
                Console.WriteLine("Nachricht gesendet.");

                byte[] buffer = new byte[1024];
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine($"Antwort vom Server: {response}");

                Console.ReadLine();
            }
        }
    }

}
