namespace P02_CarsSalesman.Core
{
    using System;
    using Contracts;
    using System.Linq;
    using Models;

    public class ProgramEngine : IProgramEngine
    {
        private CarSalesman carSalesman;

        public ProgramEngine()
        {
            this.carSalesman = new CarSalesman();
        }

        public void Run()
        {
            
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Engine engine = this.CreateEngine(parameters);
                this.AddEngine(engine);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] carArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Car car = this.CreateCar(carArgs);
                this.AddCar(car);
            }

            foreach (var car in carSalesman.Cars)
            {
                Console.WriteLine(car);
            }
        }
        public Car CreateCar(string[] carArgs)
        {
            string model = carArgs[0];
            string engineModel = carArgs[1];
            Engine engine = this.carSalesman.Engines.FirstOrDefault(x => x.Model == engineModel);
            int weight = -1;
            Car car;
            if (carArgs.Length == 3 && int.TryParse(carArgs[2], out weight))
            {
                car = new Car(model, engine, weight);
            }
            else if (carArgs.Length == 3)
            {
                string color = carArgs[2];
                car = new Car(model, engine, color);
            }
            else if (carArgs.Length == 4)
            {
                string color = carArgs[3];
                car = new Car(model, engine, int.Parse(carArgs[2]), color);
            }
            else
            {
                car = new Car(model, engine);
            }
            return car;
        }

        public Engine CreateEngine(string[] engineArgs)
        {
            Engine engine;
            string model = engineArgs[0];
            int power = int.Parse(engineArgs[1]);
            int displacement = -1;

            if (engineArgs.Length == 3 && int.TryParse(engineArgs[2], out displacement))
            {
                engine = new Engine(model, power, displacement);
            }
            else if (engineArgs.Length == 3)
            {
                string efficiency = engineArgs[2];
                engine = new Engine(model, power, efficiency);
            }
            else if (engineArgs.Length == 4)
            {
                string efficiency = engineArgs[3];
                engine = new Engine(model, power, int.Parse(engineArgs[2]), efficiency);
            }
            else
            {
                engine = new Engine(model, power);
            }
            return engine;
        }

        private void AddEngine(Engine engine)
        {
            this.carSalesman.Engines.Add(engine);
        }

        private void AddCar(Car car)
        {
            this.carSalesman.Cars.Add(car);
        }

    }
}
