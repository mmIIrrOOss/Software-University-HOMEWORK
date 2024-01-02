using SIS.WebServer.Common;
using SIS.WebServer.Enums;
using System.Text;

namespace SIS.WebServer.Extensions
{
    public static class HtttpResponseStatusExtensions
    {
        public static string GetStatusLine(this HttpResponseStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpResponseStatusCode.Ok:
                    return "200";
                case HttpResponseStatusCode.Created:
                    return "201";
                case HttpResponseStatusCode.Found:
                    return "302";
                case HttpResponseStatusCode.SeeOther:
                    return "303 See other";
                case HttpResponseStatusCode.BadRequest:
                    return "400 Bad Request"; 
                case HttpResponseStatusCode.Unauthorized:
                    return "401 Unauthorizated";
                case HttpResponseStatusCode.Forbidden:
                    return "403 Bad Forbidden";
                case HttpResponseStatusCode.NotFound:
                    return "404 Not Found";
                case HttpResponseStatusCode.InternalServerError:
                    return "500 Internal Server Error";
                default:
                    break;
            }

            return null;
        }

    }
}
