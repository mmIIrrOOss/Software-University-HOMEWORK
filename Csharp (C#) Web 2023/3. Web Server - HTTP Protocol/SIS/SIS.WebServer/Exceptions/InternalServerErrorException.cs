using System;

namespace SIS.WebServer.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private const string messageInternalServerErrorException
            = "The Server has encountered an error.";

        public InternalServerErrorException(): 
            base (messageInternalServerErrorException)
        {

        }

        public InternalServerErrorException(string message) 
            : base(message)
        {
        }
    }
}
