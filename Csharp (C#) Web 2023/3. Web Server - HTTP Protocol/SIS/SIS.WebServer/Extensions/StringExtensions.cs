namespace SIS.WebServer.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text)
        {
            string result = text[0] + text.Substring(1).ToLower();

            return result;
        }

    }
}
