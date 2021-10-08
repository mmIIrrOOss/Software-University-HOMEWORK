using SnakedGame.Helpers;
using SnakeGame;
using SnakeGame.Interfaces;
namespace SnakedGame.LinkedList
{
    public class Food : IDrawable
    {
        private bool isEaten = false;
        public Food(Position position, char symbol = '#')
        {
            this.Position = position;
            this.Symbol = symbol;
        }
        public Position Position { get; set; }
        public char Symbol { get; set; }
        public void EatFood()
        {
            ConsoleHelper.Clear(Position);
            isEaten = true;
        }

        public void Draw()
        {
            if (isEaten == false)
            {
                ConsoleHelper.Write(Position, Symbol.ToString());
            }
            
        }
    }
}
