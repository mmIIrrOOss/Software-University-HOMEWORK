namespace Animals.Models
{
    public class Animal
    {
        private string name;
        private string favoriteFood;
        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }
        public string Name { get => name; private set => name = value; }

        public string FavoriteFood { get => favoriteFood; private set => favoriteFood = value; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavoriteFood}";
        }
    }
}
