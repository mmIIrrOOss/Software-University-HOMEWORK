using SIS.WebServer.Enums;
using SIS.WebServer.Headers;
using SIS.WebServer.Responses;

namespace SIS_HTTP.Results
{
    public class RedirectResult : HttpResponse
    {

        public RedirectResult(string location)
            : base(HttpResponseStatusCode.SeeOther)
        {
            Headers.AddHeader(new HttpHeader("Location", location));
        }


    }
}
