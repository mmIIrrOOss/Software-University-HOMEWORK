namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int Comfort = 5;
        private const decimal Pirce = 10;

        public Plant() 
            : base(Comfort, Pirce)
        {
        }
    }
}
