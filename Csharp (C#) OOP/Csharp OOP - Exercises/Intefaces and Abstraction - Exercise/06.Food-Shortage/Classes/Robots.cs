namespace _06.Food_Shortage
{
    public class Robots : IIdentifiable
    {
        private string model;
        private string id;
        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get => model; private set => model = value; }
        public string Id { get => id; private set => id = value; }
    }
}
