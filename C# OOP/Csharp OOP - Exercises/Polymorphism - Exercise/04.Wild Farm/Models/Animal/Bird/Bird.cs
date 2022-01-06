namespace _04.Wild_Farm.Models.Animal.Bird
{
    using Constrains;
    using System;
    public class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double foodEaten, double wingSize)
            : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public virtual double WingSize { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
