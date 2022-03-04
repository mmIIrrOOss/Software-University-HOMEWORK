namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake : Point
    {
        private const char SnakeSymbol = '\u25CF';
        private Queue<Point> snakeElement;
        private Wall wall;
        private Food[] foods;
        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY)
            : base(leftX, topY)
        {
            this.wall = wall;
            this.snakeElement = new Queue<Point>();
            this.foods = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall)
            };
            this.CreateSnake();
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElement);

        }

        public int Length => this.snakeElement.Count;

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                var point = new Point(this.LeftX + i, this.TopY);
                point.Draw(SnakeSymbol);
                snakeElement.Enqueue(point);
            }
        }

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElement.Last();
            GetNextDirection(currentSnakeHead, direction);

            if (IsWallPoint())
            {
                return false;
            }
            if (IsPartOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.foods[foodIndex].iSFoodPoit(newHead))
            {
                this.Eat(direction, newHead);
            }
            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            var tail = this.snakeElement.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(SnakeSymbol);
            this.snakeElement.Enqueue(newHead);
            return newHead;
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.foods[foodIndex].FoodPoints; i++)
            {
                this.GetNextDirection(newHead, direction);
                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(SnakeSymbol);
                this.snakeElement.Enqueue(newHead);
            }
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElement);
        }

        private bool IsPartOfSnake()
            => this.snakeElement.Any(
                x => x.LeftX == this.LeftX && x.TopY == this.TopY);

        private bool IsWallPoint()
            => this.LeftX == 0 || this.TopY == 0 ||
                this.LeftX == this.wall.LeftX - 1 ||
                this.TopY == this.wall.TopY;

        private void GetNextDirection(Point head, Point direction)
        {
            this.LeftX = head.LeftX + direction.LeftX;
            this.TopY = head.TopY + direction.TopY;
        }
    }
}
