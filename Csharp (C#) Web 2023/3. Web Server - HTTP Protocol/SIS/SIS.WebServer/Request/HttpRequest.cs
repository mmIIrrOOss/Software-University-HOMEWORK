using SIS.WebServer.Common;
using SIS.WebServer.Enums;
using SIS.WebServer.Headers;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.WebServer.Request
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowNullOffEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLines)
        {
            if (requestLines.Length != 3
                || requestLines[2] != GlobalConstants.HttpOneProtocolFragment)

            {
                return false;
            }
            return true;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            throw new NotImplementedException();
        }

        private void ParseRequestMethod(string[] requestString)
        {
            HttpRequestMethod method;
            bool parseResult = HttpRequestMethod.TryParse(requestString[0], out method);

            if (!parseResult)
            {
                throw new BadImageFormatException(string.Format
                    (GlobalConstants
                            .UnSupportedHttpMethodExceptionMessage, requestString[0]));
            }
            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }
        
        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseRequestHeaders(string[] requestHeaders)
        {
            requestHeaders
                .Select(x => x.Split(new[] { ',', ':' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headersKeyValuePair => this.Headers
                                            .AddHeader(new HttpHeader( 
                                            headersKeyValuePair[0], headersKeyValuePair[1])));
        }

        private void ParseRequestCookies()
        {

        }

        private void ParseRequestQueryParameters()
        {
            this.Url.Split('?')[1]
                .Split('&')
                .Select(qm => qm.Split('='))
                .ToList()
                .ForEach(parseQueryParameter => 
                this.QueryData.Add(parseQueryParameter[0], parseQueryParameter[1]));
        }

        private void ParseRequestFormDataParameters(string formData)
        {
            formData.Split('&')
                .Select(qm => qm.Split('='))
                .ToList()
                .ForEach(parseQueryParameter =>
                this.FormData.Add(parseQueryParameter[0], parseQueryParameter[1]));
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, System.StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0]
                .Trim()
                .Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadImageFormatException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);

        }
    }
}
