namespace Cars.Models
{
    using Models.Constrains;

    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }
        public string Model
        {
            get => model;
            set
            {
                model = value;
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public void Start()
        {
            Console.WriteLine("Start Engine Breaaak!");
        }

        public void Stop()
        {

        }
        public override string ToString()
        {
            return $"{Color} {GetType().Name} {Model}";
        }
    }
}
