namespace _03.Telephony
{
    using _03.Telephony.ExceptionMessages;
    using System;
    using System.Linq;
    public class Smartphone : ICall,IBrowsing
    {
        
        public string PhoneNumber { get; private set; }
        public string WebSite { get; private set; }

        public string Browse(string website)
        {
            if (website.Any(x=>char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {website}!";
        }

        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(x=>char.IsLetter(x)||char.IsWhiteSpace(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Calling... {phoneNumber}";
        }

        
    }
}
