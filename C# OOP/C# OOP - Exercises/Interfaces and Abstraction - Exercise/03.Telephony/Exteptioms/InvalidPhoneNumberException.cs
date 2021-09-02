

namespace ManufacturingPhones
{
	using System;
	public class InvalidPhoneNumberException:Exception
	{
		private const string Invalid_Phone_Number_Exception="Invalid number!";
		public InvalidPhoneNumberException()
			:base(Invalid_Phone_Number_Exception)
		{

		}
	}
}
