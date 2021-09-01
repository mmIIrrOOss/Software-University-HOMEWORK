

namespace Shapes
{
	using System;
	public class Rectangle : IDrawable
	{
		public Rectangle(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}
		public int Width { get => width; set => width = value; }
		public int Height { get => height; set => height = value; }
		private int width;
		private int height;

		public void Draw()
		{
			DrawLine(this.width, '*', '*');
			for (int i = 0; i < this.height - 1; ++i)
			{
				DrawLine(this.width, '*', ' ');
			}
			DrawLine(this.width, '*', '*');
		}
		private void DrawLine(int width, char end, char mid)
		{
			Console.WriteLine(end);
			for (int i = 1; i < width - 1; ++i)
			{
				Console.Write(mid);
			}
			Console.WriteLine(end);
		}
	}
}
