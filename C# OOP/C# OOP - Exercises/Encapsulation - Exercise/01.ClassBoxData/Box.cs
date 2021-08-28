

namespace ClassBoxData
{
	using System;


	public class Box
	{

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}
		public double Length
		{
			get => this.length;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Length cannot be zero or negative.");
				}
				this.length = value;
			}
		}
		public double Height
		{
			get => height;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Height cannot be zero or negative.");
				}
				this.height = value;
			}

		}
		public double Width
		{
			get => this.width;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Width cannot be zero or negative.");
				}
				this.width = value;
			}
		}
		private double width;
		private double length;
		private double height;

		public double GetSurfaceArea(double length, double width, double height)
		{
			return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
		}
		public double GetLateralSurfaceArea(double length, double width, double height)
		{
			return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
		}
		public double GetVolume(double length, double width, double height)
		{
			return this.Length * this.Width * this.Height;
		}

	}
}
