namespace _03.Template_Pattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            System.Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
