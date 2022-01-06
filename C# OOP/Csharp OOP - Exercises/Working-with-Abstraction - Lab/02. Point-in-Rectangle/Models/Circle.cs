namespace _02._Point_in_Rectangle.Models
{
    using System;
    using Models.Constrains;

    public class Circle : IPointContainable
    {

        public Circle(int x, int y, int radius)
        {
            this.Center = new Point(x, y);
            this.Radius = radius;
        }

        public Point Center { get; set; }

        public int Radius { get; set; }

        public bool Contains(Point point)
        {
            var distance = Math.Sqrt((point.X - this.Center.X) * (point.X - this.Center.X)
                + (point.Y - this.Center.Y) * (point.Y - this.Center.Y));

            if (distance <= this.Radius)
            {
                return true;
            }
            return false;
        }
    }
}
