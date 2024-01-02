using SIS.WebServer.Enums;
using SIS_HTTP;
using SIS_HTTP.Routing;
using SIS_HTTP.Routing.Contracts;

namespace Demo.App
{
    public class Launcher
    {

        public static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController()
            .Index(request));

            Server server = new Server(8080, serverRoutingTable);
            server.Run();
        }

    }
}
