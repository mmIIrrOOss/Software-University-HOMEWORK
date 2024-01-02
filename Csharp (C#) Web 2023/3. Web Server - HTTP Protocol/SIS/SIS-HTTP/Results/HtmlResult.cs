using SIS.WebServer.Enums;
using SIS.WebServer.Headers;
using SIS.WebServer.Responses;
using System.Text;

namespace SIS_HTTP.Results
{
    public class HtmlResult : HttpResponse
    {

        public HtmlResult(string ccontent, HttpResponseStatusCode responseStatusCode)
            : base(responseStatusCode)
        {
            Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            Content = Encoding.UTF8.GetBytes(ccontent);
        }


    }
}
