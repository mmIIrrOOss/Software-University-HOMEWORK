namespace _06.Food_Shortage.Classes
{
    public class Rebel :  IBuyer,IAge
    {
        private string name;
        private int age;
        private string group;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }
        public string Group { get => group; private set => group = value; }

        public int Food { get; private set; } = 0;

        public int BuyFood()
        {
            return this.Food += 5;
        }
    }
}
