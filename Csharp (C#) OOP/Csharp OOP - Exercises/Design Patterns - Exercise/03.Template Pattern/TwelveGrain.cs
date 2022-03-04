namespace _03.Template_Pattern
{
    using System;

    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
