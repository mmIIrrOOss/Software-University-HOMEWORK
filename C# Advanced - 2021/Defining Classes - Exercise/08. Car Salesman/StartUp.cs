using System;
using System.Collections.Generic;
using System.Linq;
namespace _08._Car_Salesman
{
	class StartUp
	{
		static void Main(string[] args)
		{
            List<Engine> engines = new List<Engine>();
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < n; i++)
			{
				string[] engineInfo = Console.ReadLine().Split(new char[] { ' ' });
				string model = engineInfo[0];
				int powerEngine = int.Parse(engineInfo[1]);
				Engine eng = new Engine(model,powerEngine);
                if (engineInfo.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        eng.Displacement = displacement;
                    }
                    else
                    {
                        eng.Efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement;
                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        eng.Displacement = displacement;
                        eng.Efficiency = engineInfo[3];
                    }
                    else
                    {
                        eng.Efficiency = engineInfo[2];
                        eng.Displacement = int.Parse(engineInfo[3]);
                    }
                }
                engines.Add(eng);
            }
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());
            while (carsCount-- > 0)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carsData[0];
                Engine engine = engines.Where(e => e.Model == carsData[1]).First();
                Car car = new Car(model, engine);

                if (carsData.Length == 3)
                {
                    int weight;
                    if (int.TryParse(carsData[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carsData[2];
                    }
                }
                else if (carsData.Length == 4)
                {
                    int weight;
                    if (int.TryParse(carsData[2], out weight))
                    {
                        car.Weight = weight;
                        car.Color = carsData[3];
                    }
                    else
                    {
                        car.Color = carsData[2];
                        car.Weight = int.Parse(carsData[3]);
                    }
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
	}
}
