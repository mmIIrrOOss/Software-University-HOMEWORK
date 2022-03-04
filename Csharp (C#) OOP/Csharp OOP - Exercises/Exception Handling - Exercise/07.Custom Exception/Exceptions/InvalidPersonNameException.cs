namespace _07.Custom_Exception.Exceptions
{
    using System;

    public class InvalidPersonNameException:Exception
    {
        private const string Invalid_Person_Exc = "Invalid Person!";

        public InvalidPersonNameException()
            :base(Invalid_Person_Exc)
        {

        }
    }
}
