using SIS.WebServer.Common;
using SIS.WebServer.Enums;
using SIS.WebServer.Extensions;
using SIS.WebServer.Headers;
using SIS.WebServer.Responses.Contracts;
using System.Text;

namespace SIS.WebServer.Responses
{
    public class HttpResponse : IHttpResponse
    {


        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
            : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; }
        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] htttpResponseWithoutBody = Encoding.UTF8.GetBytes(this.ToString());
            byte[] httpResponseBytesWithBody = new byte[htttpResponseWithoutBody.Length
                + this.Content.Length];

            for (int i = 0; i < htttpResponseWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i] = htttpResponseWithoutBody[i];
            }


            for (int i = 0; i < httpResponseBytesWithBody.Length - htttpResponseWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i + htttpResponseWithoutBody.Length] = this.Content[i];
            }

            return httpResponseBytesWithBody;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
