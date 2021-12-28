namespace _03.Telephony
{
    using _03.Telephony.ExceptionMessages;
    using System;
    using System.Linq;

    public class StationaryPhone : ICall
    {

        public string PhoneNumber { get; private set; }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Dialing... {phoneNumber}";
        }

    }
}
