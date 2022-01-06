namespace _04.Border_Control
{
    public class Robot : IIdentifiable
    {
        private string model;
        private string id;
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get => model; private set => model = value; }
        public string Id { get => id; private set => id = value; }
    }
}
