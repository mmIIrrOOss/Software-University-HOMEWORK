using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {



        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderColllection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split('\r', '\n');
            var startLine = lines.First().Split(' ');

            var method = ParseMethod(startLine[0]);
            var url = startLine[1];

            return method.
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {

                throw new InvalidOperationException($"Method '{method}' is not supported");
            }

            var headers = ParseHeaders(lines.Skip(1));
        }

        private static HeaderColllection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderColllection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(':', 2);
                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[i].Trim();
                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }
    }
}
