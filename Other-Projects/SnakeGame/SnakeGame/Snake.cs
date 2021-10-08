using SnakedGame;
using SnakedGame.Helpers;
using SnakedGame.LinkedList;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;


namespace SnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position head, Action spawnFood)
        {
            SpawnFood = spawnFood;
            SnakeBody = new LinkedListt();
            SnakeBody.AddHead(new Node(head));
            Foods = new List<Food>();
            for (int i = 1; i <= 10; i++)
            {
                SnakeBody.AddLast(new Node(new Position(head.X + i, head.Y)));

            }
        }
        public Action SpawnFood { get; set; }
        public LinkedListt SnakeBody { get; set; }
        public List<Food> Foods { get; set; }
        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                var text = "*";
                if (n == SnakeBody.Head)
                {
                    text = "O";
                }
                ConsoleHelper.Write(n.Value, text);
            });
        }

        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }
            ConsoleHelper.Clear(SnakeBody.Tail.Value);
            SnakeBody.ReverseForEach(n =>
            {
                if (n.PreviousNode != null)
                {
                    n.Value.X = n.PreviousNode.Value.X;
                    n.Value.Y = n.PreviousNode.Value.Y;
                }
            });
            SnakeBody.Head.Value.ChangePosition(position);
            for (int i = 0; i < Foods.Count; i++)
            {
                if (Foods[i].Position == SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(position);
                    SpawnFood();
                    SpawnFood();
                }
            }
        }
        public bool CheckSelfCanibalism()
        {
            HashSet<Position> set = new HashSet<Position>();
            bool isCanibal = false;
            SnakeBody.ForEach(n =>
            {
                if (set.Contains(n.Value))
                {
                    isCanibal = true;
                }
                set.Add(n.Value);
            });
            return isCanibal;
        }
        public void Grow(Position position)
        {
            var reverse = new Position(position.X * -1, position.Y * -1);
            var oldPosition = SnakeBody.Tail.Value;

            var newHead = new Node(new Position(oldPosition.X, oldPosition.Y));
            newHead.Value.ChangePosition(reverse);
            BounderiesChecker.CheckBoundaries(newHead.Value, reverse);
            SnakeBody.AddLast(newHead);
        }
    }
}
