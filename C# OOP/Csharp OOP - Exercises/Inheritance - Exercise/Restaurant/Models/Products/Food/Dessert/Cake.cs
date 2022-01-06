namespace Restaurant.Models.Products.Food.Dessert
{
    public class Cake : Dessert
    {
        private const double Grams = 350;
        private const double Calories = 1000;
        private const decimal CakePrice = 5;
        public Cake(string name)
            : base(name, CakePrice, Grams, Calories)
        {

        }
    }
}
