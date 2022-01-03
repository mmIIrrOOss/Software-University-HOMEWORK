namespace _01.Logger.Models.Layouts
{
    using Constrains;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
