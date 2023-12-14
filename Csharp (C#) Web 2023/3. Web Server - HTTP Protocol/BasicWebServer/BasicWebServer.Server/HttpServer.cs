using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly string newLine = "\r\n";

        public HttpServer(string ipAdress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, this.port);
        }

        public void Start()
        {
            this.serverListener.Start();
            Console.WriteLine($"Server started on port {this.port}.");
            Console.WriteLine("Listening for request...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkSttream = connection.GetStream();
                var requestTest = this.ReadRequest(networkSttream);
                Console.WriteLine(requestTest);
                connection.Close();
            }
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;
                if (totalBytes > 18 * 1024)
                {
                    throw new InvalidOperationException("Request is the large.");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));


            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private void WriteRespone(NetworkStream networkSttream, string message)
        {
            var contentLength = Encoding.UTF8.GetByteCount(message);

            var response = $@"HTTP/1.1 200 OK" + newLine +
                "Content-Type: text/plain; charset=UTF-8" + newLine +
                "Content-Length: " + contentLength + newLine +
                message;

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkSttream.Write(responseBytes, 0, response.Length);
        }
    }
}
