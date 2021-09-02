

namespace FoodShortage
{
	using System;
	public class Robots : IIdentifiable
	{

		public Robots(string model, string id)
		{
			this.model = model;
			this.Id = id;
		}

		public string Id { get; private set; }
		private string model;

	}
}
