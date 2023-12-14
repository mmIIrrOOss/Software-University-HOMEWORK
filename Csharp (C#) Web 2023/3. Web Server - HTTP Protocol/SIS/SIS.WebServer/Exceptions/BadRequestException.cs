using System;

namespace SIS.WebServer.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string messageBadRequestException 
            = "The Request was malformed or contains unsupported elements.";

        public BadRequestException() :
            base(messageBadRequestException)
        {

        }

        public BadRequestException(string message) :
            base(message)
        {

        }
    }
}
