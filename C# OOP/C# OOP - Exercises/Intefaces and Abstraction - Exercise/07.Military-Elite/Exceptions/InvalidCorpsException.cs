using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private  const string Invalid_Corps_Exception = "Invalid corps!";
        public InvalidCorpsException()
            :base(Invalid_Corps_Exception)
        {

        }
        public InvalidCorpsException(string message)
            : base(message)
        {

        }
    }
}
