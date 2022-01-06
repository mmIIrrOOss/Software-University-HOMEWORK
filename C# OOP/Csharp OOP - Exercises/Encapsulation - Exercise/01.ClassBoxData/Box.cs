namespace _01.ClassBoxData
{
    using System;
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Lenght = length;
            this.Height = height;
            this.Width = width;
        }
        public double Lenght
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");

                }
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");

                }
                this.height = value;
            }
        }
        public double GetSurfaceArea()
        {
            double surfaceArea = (2 * this.length * this.Width) +
                (2 * this.Lenght * this.Height) + (2 * this.Width * this.Height);
            return surfaceArea;
        }
        public double GetLiteralSurfaceArea()
        {
            double literalSurfaceArea = (2 * this.Lenght * this.Height)
                + (2 * this.Width * this.Height);
            return literalSurfaceArea;
        }
        public double GetVolume()
        {
            double volume = this.Lenght * this.Height * this.Width;
            return volume;
        }
    }
}
