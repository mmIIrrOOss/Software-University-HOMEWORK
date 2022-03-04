namespace _03.Template_Pattern
{
    using System;

    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Sourdough Bread (20 minutes)");
        }
    }
}
