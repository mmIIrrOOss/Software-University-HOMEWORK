namespace P01_RawData.Core
{
    using P01_RawData.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO;

    public class ProgramEngine : IEngine
    {
        private IList<Car> cars;
        private readonly List<Tire> carTires;

        public ProgramEngine()
        {
            cars = new List<Car>();
            carTires = new List<Tire>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());
            ParseInput(lines);
            PrintOutput();
        }

        private void ParseInput(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Engine engine = CreateEngine(engineSpeed, enginePower);
                Cargo cargo = CreateCargo(cargoWeight, cargoType);
                ReafTires(parameters);
                Car car = CreateCar(model, engine, cargo, carTires);
                cars.Add(car);
            }
        }

        private void PrintOutput()
        {
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private Car CreateCar(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Car car = new Car(model, engine, cargo, tires.ToArray());
            return car;
        }

        private void ReafTires(string[] parameters)
        {
            for (int j = 5; j <= 12; j += 2)
            {
                double currentTirePressure = double.Parse(parameters[j]);
                int currentTireAge = int.Parse(parameters[j + 1]);
                Tire currentTire = CreateTire(currentTireAge, currentTirePressure);
                carTires.Add(currentTire);
            }
        }

        private Engine CreateEngine(int speed, int power)
        {
            Engine engine = new Engine(speed, power);
            return engine;
        }

        private Cargo CreateCargo(int weight, string type)
        {
            Cargo cargo = new Cargo(weight, type);
            return cargo;
        }

        private Tire CreateTire(int age, double pressure)
        {
            Tire tire = new Tire(age, pressure);
            return tire;
        }
    }
}
