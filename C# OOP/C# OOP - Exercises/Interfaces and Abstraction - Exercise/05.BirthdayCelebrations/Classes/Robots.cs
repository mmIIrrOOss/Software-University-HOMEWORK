

namespace FoodShortage
{
	using System;
	public class Robots : IIdentifiable, ITypeName
	{
		public Robots(string typeName,string model,string id)
		{
			this.TypeName = typeName;
			this.Model = model;
			this.Id = id;
		}
		public string TypeName { get;  private set; }
		public string Model { get; private set; }
		public string Id { get; private set; }

		
	}
}
