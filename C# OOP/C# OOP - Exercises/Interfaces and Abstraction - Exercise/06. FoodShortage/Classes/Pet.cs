using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
	public class Pet : IBirthdatetable
	{
		public Pet(string name, string birthdate)
		{
			
			this.Name = name;
			this.Birthdate = birthdate;
		}
		public string Name { get;  set; }
		public string Birthdate { get; private set; }
	}
}
