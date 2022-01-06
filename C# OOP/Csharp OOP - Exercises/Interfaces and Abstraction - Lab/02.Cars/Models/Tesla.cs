namespace Cars.Models
{
    using Constrains;
    using System;

    public class Tesla : ICar, IElectricCar
    {

        private string model;
        private string color;
        public Tesla(string model, string color, int batery)
        {
            Model = model;
            Color = color;
            Battery = batery;
        }
        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public int Battery { get; set; }

        public void Start()
        {
            Console.WriteLine("Start Engine Breaaak!");
        }

        public void Stop()
        {

        }
        public override string ToString()
        {
            return $"{Color} {GetType().Name} {Model} with {Battery} Batteries";
        }
    }
}
