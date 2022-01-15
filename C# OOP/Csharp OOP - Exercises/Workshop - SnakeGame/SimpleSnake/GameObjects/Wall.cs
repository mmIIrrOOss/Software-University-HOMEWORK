namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.SetHorizontalLine();
            this.SetVerticalline();
        }

        public void SetHorizontalLine()
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, 0, '\u25A0');
            }
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, this.TopY - 1, '\u25A0'); ;
            }
        }

        public void SetVerticalline()
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(0, topY, '\u25A0');
            }
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(this.LeftX, topY, '\u25A0');
            }
        }
    }
}
