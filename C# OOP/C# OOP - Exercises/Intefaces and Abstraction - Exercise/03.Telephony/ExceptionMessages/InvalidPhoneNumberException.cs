namespace _03.Telephony.ExceptionMessages
{
    using System;
    public class InvalidPhoneNumberException:Exception
    {
        private const string InvalidPhoneNumber_Exception = "Invalid number!";
        public InvalidPhoneNumberException()
            :base(InvalidPhoneNumber_Exception)
        {
                
        }
    }
}
