using SIS.WebServer.Enums;
using SIS.WebServer.Headers;
using System.Collections.Generic;

namespace SIS.WebServer.Request
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; } 

        HttpRequestMethod RequestMethod { get; }
    }
}
