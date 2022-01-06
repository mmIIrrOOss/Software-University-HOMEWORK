namespace _06.Food_Shortage
{
    public class Citizens : IBIrthdate, IBuyer,IAge,IIdentifiable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizens(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get => name; private set => name = value; }

        public int Age { get => age; private set => age = value; }

        public string Id { get => this.id; private set => this.id = value; }

        public string Birthdate { get => birthdate; private set => this.birthdate = value; }

        public int Food { get; private set; } = 0;

        public int BuyFood()
        {
            return this.Food += 10;
        }
    }
}
