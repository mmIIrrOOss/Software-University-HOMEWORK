
namespace FoodShortage
{
	using System;
	public class Citizens : IIdentifiable, ITypeName, IBirthdatetable, IName
	{
		public Citizens(string typeName, string name, int age, string id, string birthdate)
		{
			this.TypeName = typeName;
			this.Name = name;
			this.Age = age;
			this.Id = id;
			this.Birthdate = birthdate;
		}
		public string TypeName { get; private set; }
		public string Name { get; private set; }
		public int Age { get; private set; }
		public string Id { get; private set; }


		public string Birthdate { get; private set; }
	}
}
