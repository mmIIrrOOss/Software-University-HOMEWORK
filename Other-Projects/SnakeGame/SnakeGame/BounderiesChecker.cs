using System;
using SnakeGame;
using SnakedGame.Helpers;
namespace SnakedGame
{
    public class BounderiesChecker
    {
        public static void CheckBoundaries(Position headPosition, Position movement)
        {
            var newPosition = headPosition.GetNewPosition(movement);
            if (newPosition.Y <= -1)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.Y = Console.WindowHeight - 1;
            }
            if (newPosition.X <= -1)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.X = Console.WindowHeight - 1;
            }
            if (newPosition.X >= Console.WindowHeight)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.X = 0;
            }
            if (newPosition.Y >= Console.WindowHeight)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.Y = 0;
            }
            
        }
    }
}
