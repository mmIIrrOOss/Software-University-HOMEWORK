namespace P02_CarsSalesman.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarSalesman
    {
        private List<Car> cars;

        private List<Engine> engines;

        public CarSalesman()
        {
            this.Cars = new List<Car>();
            this.Engines = new List<Engine>();
        }

        public List<Car> Cars { get => this.cars; private set => this.cars = value; }

        public List<Engine> Engines { get => this.engines; private set => this.engines = value; }

        

    }

}
