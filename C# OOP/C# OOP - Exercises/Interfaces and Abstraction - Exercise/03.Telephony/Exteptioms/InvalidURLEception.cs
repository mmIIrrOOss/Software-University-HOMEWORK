

namespace ManufacturingPhones
{
	using System;
	public class InvalidURLEception : Exception
	{
		private const string Invalid_URL_Message = "Invalid URL!";
		public InvalidURLEception()
			:base(Invalid_URL_Message)
		{

		}
	}
}
