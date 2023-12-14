using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {

        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add("Server", "My Web server");
            this.Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }

        public StatusCode  StatusCode { get; set; }

        public HeaderColllection Headers { get; set; }

        public string Body { get; set; }
    }
}
