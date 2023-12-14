using SIS.WebServer.Common;
using System.Collections.Generic;

namespace SIS.WebServer.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowNullOffEmpty(header.Key, nameof(header));
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowNullOffEmpty(key, nameof(key));
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowNullOffEmpty(key, nameof(key));
            return this.headers[key];
        }


    }
}
