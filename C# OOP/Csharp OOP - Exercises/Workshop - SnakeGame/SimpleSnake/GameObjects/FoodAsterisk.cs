namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int Points = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, foodSymbol, Points)
        {
        }

    }
}
