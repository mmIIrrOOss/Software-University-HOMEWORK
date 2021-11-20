namespace _01.RhombusofStars.Models
{
    using System;
    using System.Text;


    public class RhombusAsString 
    {
        public string Draw(int countOfStars)
        {
            StringBuilder sb = new StringBuilder();
            this.DrawTopPart(sb, countOfStars);
            this.DrawOfStars(sb, countOfStars);
            this.DrawBottomPart(sb, countOfStars);
            return sb.ToString().TrimEnd();
        }
        private void DrawOfStars(StringBuilder sb, int numberOfStars)
        {
            for (int star = 0; star < numberOfStars; star++)
            {
                sb.Append('*');
                if (star < numberOfStars - 1)
                {
                    sb.Append(' ');
                }
            }
            //sb.Append(new string(' ', lines - i - 1));
            sb.AppendLine();
        }

        private void DrawTopPart(StringBuilder sb, int line)
        {
            for (int i = 1; i < line; i++)
            {
                sb.Append(new string(' ', line - i));
                DrawOfStars(sb, i);
            }
        }

        private void DrawBottomPart(StringBuilder sb, int line)
        {
            for (int i = line - 1; i >= 1; i--)
            {
                sb.Append(new string(' ', line - i));
                DrawOfStars(sb, i);
            }
        }
    }
}
