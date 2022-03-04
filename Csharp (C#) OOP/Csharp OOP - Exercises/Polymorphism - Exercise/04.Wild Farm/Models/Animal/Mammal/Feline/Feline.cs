namespace _04.Wild_Farm.Models.Animal.Mammal.Feline
{
    using Models.Constrains;

    public class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, double foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public virtual string Breed { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
