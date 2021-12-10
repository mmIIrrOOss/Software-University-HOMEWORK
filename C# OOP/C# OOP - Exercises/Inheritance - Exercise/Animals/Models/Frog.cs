namespace Animals.Models
{
    using Animals.Models.Constrains;
    
    public class Frog : Animal, IProduceSound
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
