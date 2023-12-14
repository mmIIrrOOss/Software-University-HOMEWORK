using BasicWebServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Demo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ipAddress = "127.0.0.1";
            var port = 8080;

            var server = new HttpServer(ipAddress, port);
            server.Start();
        }
    }
}
