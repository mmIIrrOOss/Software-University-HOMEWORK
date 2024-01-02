using SIS.WebServer.Enums;
using SIS.WebServer.Headers;
using SIS.WebServer.Responses;
using System.Text;

namespace SIS_HTTP.Results
{
    public class TextResult : HttpResponse
    {



        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8") : base(responseStatusCode)
        {
            Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8") : base(responseStatusCode)
        {
            Content = content;
            Headers.AddHeader(new HttpHeader("Content-Type", contentType));
        }


    }
}
