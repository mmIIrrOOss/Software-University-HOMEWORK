namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int Points = 2;

        public FoodHash(Wall wall) 
            : base(wall, FoodSymbol, Points)
        {
        }
    }
}
