

namespace BorderControl
{
	using System;
	public class Robots:IIdentifiable
	{
		public Robots(string model,string id)
		{
			this.Model = model;
			this.Id = id;
		}
		public string Model { get; private set; }

		public string Id { get; private set; }
	}
}
