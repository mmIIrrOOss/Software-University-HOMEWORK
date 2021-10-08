using SnakedGame;
using SnakedGame.Helpers;
using SnakedGame.LinkedList;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    public class GameEngine
    {
        private bool isStarted = false;
        private List<IDrawable> gameItems = new List<IDrawable>();
        public Snake Snake { get; set; }
        private Random random = new Random();
        public GameEngine()
        {
            Snake = new Snake(new Position(30, 20),SpawnFood);
            gameItems.Add(Snake);
            for (int i = 0; i < 6; i++)
            {
                SpawnFood();
            }
        }
        public void Start()
        {
            isStarted = true;
            Position movementPosition = new Position(0, 0);

            while (isStarted = true)
            {
                BounderiesChecker.CheckBoundaries(Snake.SnakeBody.Head.Value, movementPosition);
                Snake.Move(movementPosition);
                if(Snake.CheckSelfCanibalism())
                {
                    Console.Clear();
                    ConsoleHelper.Write(new Position(0, 0),"Game Over!You ate selfff??"+Environment.NewLine+"MUAHAHAHA");
                     isStarted = false;
                    break;
                }
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false).Key;
                    movementPosition = ReadUserInput.GetMovement(key,movementPosition);
                }
                Thread.Sleep(40);
                gameItems.ForEach(i => i.Draw());
            }
        }
        public void Stop()
        {
            isStarted = false;
        }
        private void SpawnFood()
        {
            var food = new Food(new Position(
                    random.Next(0, Console.WindowWidth-1),
                    random.Next(0, Console.WindowHeight-1)));
            gameItems.Add(food);
            Snake.Foods.Add(food);
        }
    }
}
