namespace _04.Border_Control
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get => name; private set => name = value; }
        public int Age { get => age; private set => age = value; }

        public string Id { get => this.id; private set => this.id = value; }
    }
}
