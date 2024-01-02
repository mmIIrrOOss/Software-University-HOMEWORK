using SIS.WebServer.Enums;
using SIS.WebServer.Request;
using SIS.WebServer.Responses.Contracts;
using SIS_HTTP.Results;



namespace Demo.App
{
    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            string content = "<h1>Hello, world!</h1>";
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

    }
}
