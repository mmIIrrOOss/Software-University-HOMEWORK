using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer
{
    class Program
    {
        const string IpAdress = "127.0.0.1";
        const int Port = 8080;
        const string NewLine = "\r\n";
        static void Main(string[] args)
        {

            var ipAdress = IPAddress.Parse(IpAdress);
            var serverListener = new TcpListener(ipAdress, Port);
            serverListener.Start();

            Console.WriteLine($"Server started on port {Port}.");
            Console.WriteLine("Listening for request...");

            var connection = serverListener.AcceptTcpClient();
            var networkStream = connection.GetStream();

            var content = "Hello from server!";
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK" + NewLine +
                "Content-Type: text/plain; charset=UTF-8" + NewLine +
                "Content-Length: " + contentLength + NewLine +
                NewLine +
                content;

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes, 0, responseBytes.Length);
            connection.Close();
        }
    }
}
