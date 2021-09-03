

namespace Animals
{
	public class Animal
	{
		public Animal(string name, string favoriteFood)
		{
			this.Name = name;
			this.FavouriteFood = favoriteFood;
		}

		public string Name { get => name; set => name = value; }
		public string FavouriteFood { get => favouriteFood; set => favouriteFood = value; }
		private string name;
		private string favouriteFood;

		public virtual string ExplainSelf()
		{
			return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
		}
	}
}
