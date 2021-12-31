namespace _04.Wild_Farm.Models.Food
{
    public class Seeds : Food
    {
        public Seeds(int quantity) 
            : base(quantity)
        {
        }

        public override int Quantity  { get ; set ; }
    }
}
