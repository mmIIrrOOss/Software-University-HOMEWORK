namespace _02._Point_in_Rectangle.Models
{
    using Models.Constrains;

    public class Rectangle : IPointContainable
    {
        public Rectangle(int top, int left, int bottom, int right)
        {
            this.TopLeftCoordinates = new Point(left, top);
            this.BottomCoordinates = new Point(right, bottom);
        }

        public Point TopLeftCoordinates { get; set; }

        public Point BottomCoordinates { get; set; }

        public bool Contains(Point point)
        {
            bool isInX = point.X >= this.TopLeftCoordinates.X &&
                point.X <= this.BottomCoordinates.X;

            bool isInY = point.Y <= this.TopLeftCoordinates.Y &&
                point.Y >= this.BottomCoordinates.Y;

            return isInX && isInY;
        }
    }
}
