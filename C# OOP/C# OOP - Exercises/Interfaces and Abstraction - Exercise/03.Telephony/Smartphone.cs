

namespace ManufacturingPhones
{
	using System;
	using System.Linq;
	public class Smartphone : ICallable, IBrowsable
	{
		
		public string Browse(string site)
		{
			if (site.Any(x=>char.IsDigit(x)))
			{
				throw new InvalidURLEception();
			}
			return $"Browsing: {site}!";
		}

		public string Call(string phoneNumber)
		{
			if (phoneNumber.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
			{
				throw new InvalidPhoneNumberException();
			}
			return $"Calling... {phoneNumber}";
		}
	}
}
