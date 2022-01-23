namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int Comfort = 1;
        private const decimal Pirce = 5;

        public Ornament() 
            : base(Comfort, Pirce)
        {
        }
    }
}
