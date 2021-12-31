namespace _04.Wild_Farm.Models.Animal.Mammal
{

    using Models.Constrains;

    public class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, double foodEaten, string livingRegion) 
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public virtual string LivingRegion { get; set; }


    }
}
