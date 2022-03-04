namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;

        protected Food(Wall wall, char symbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.FoodPoints = foodPoints;
            this.Symbol = symbol;
            this.wall = wall;
            this.random = new Random();
        }

        public char Symbol { get; private set; }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            this.LeftX = this.random.Next(1, this.wall.LeftX - 1);
            this.TopY = this.random.Next(1, this.wall.TopY - 1);

            var isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            while (isPartOfSnake)
            {
                this.LeftX = this.random.Next(1, this.wall.LeftX - 1);
                this.TopY = this.random.Next(1, this.wall.TopY - 1);
                isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }
            this.Draw(this.LeftX, this.TopY, this.Symbol);

        }

        public bool iSFoodPoit(Point snake)
            => this.LeftX == snake.LeftX &&
            this.TopY == snake.TopY;
    }
}
