

namespace ManufacturingPhones
{
	using System;
	using System.Linq;

	public class StationaryPhone : ICallable
	{
		
		public string Call(string phoneNumber)
		{
			if ((phoneNumber.All(x=>char.IsLetter(x)||char.IsWhiteSpace(x))))
			{
				throw new InvalidPhoneNumberException();
			}
			return $"Dialing... {phoneNumber}";
		}
	}
}
