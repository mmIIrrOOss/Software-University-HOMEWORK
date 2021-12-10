namespace Animals
{
    using Animals.Models;
    using Animals.Models.Constrains;

    public class Dog : Animal, IProduceSound
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {

        }


        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
