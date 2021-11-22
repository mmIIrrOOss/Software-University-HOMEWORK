namespace P01_RawData.Models
{
    using System.Collections.Generic;

    public class Car
    {
        private readonly Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.tires = tires;
        }
        public Cargo Cargo { get; }

        public Engine Engine { get; }

        public string Model { get; private set; }

        public IReadOnlyCollection<Tire> Tires
        {
            get => tires;
        }
    }
}
