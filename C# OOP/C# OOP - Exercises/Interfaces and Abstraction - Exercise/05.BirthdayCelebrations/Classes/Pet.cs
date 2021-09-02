using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
	public class Pet : ITypeName, IBirthdatetable, IName
	{
		public Pet(string typeName, string name, string birthdate)
		{
			this.TypeName = typeName;
			this.Name = name;
			this.Birthdate = birthdate;
		}
		public string TypeName { get; private set; }
		public string Name { get; private set; }
		public string Birthdate { get; private set; }
	}
}
