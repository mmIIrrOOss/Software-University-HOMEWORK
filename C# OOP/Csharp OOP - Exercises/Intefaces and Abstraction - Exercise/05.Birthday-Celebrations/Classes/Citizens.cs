namespace _05.Birthday_Celebrations
{
    public class Citizens :  IBIrthdate
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizens(string name, int age, string id,string birthdate)
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
    }
}
