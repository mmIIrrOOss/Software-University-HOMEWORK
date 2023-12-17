namespace SIS.WebServer.Common
{
    public static class GlobalConstants
    {
        public static string HttpOneProtocolFragment = "HTTP/1.1";
               
        public static string HostHeaderKey = "Host";
               
        public static string HttpNewLine = "\r\n";

        public static string UnSupportedHttpMethodExceptionMessage
            = "This HTTP Method - {0} is not supported";
    }
}
