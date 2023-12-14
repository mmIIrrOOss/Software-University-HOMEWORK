using SIS.WebServer.Common;

namespace SIS.WebServer.Headers
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowNullOffEmpty(value, nameof(key));
            CoreValidator.ThrowNullOffEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
