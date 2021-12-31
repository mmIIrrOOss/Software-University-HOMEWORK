namespace _04.Wild_Farm.Models.Constrains
{
    public interface IMammal
    {
        public string LivingRegion { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double FoodEaten { get; set; }
    }
}
