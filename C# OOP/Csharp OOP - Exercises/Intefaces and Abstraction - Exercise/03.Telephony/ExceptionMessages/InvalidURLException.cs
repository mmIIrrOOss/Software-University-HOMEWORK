namespace _03.Telephony.ExceptionMessages
{
    using System;
    public class InvalidURLException:Exception
    {
        private const string InvalidURL_Exception = "Invalid URL!";
        public InvalidURLException()
            :base(InvalidURL_Exception)
        {

        }
    }
}
