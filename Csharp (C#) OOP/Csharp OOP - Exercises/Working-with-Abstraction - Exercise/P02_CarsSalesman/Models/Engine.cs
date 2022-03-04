namespace P02_CarsSalesman.Models
{
    using System.Text;

    public class Engine
    {
        private const string offset = "  ";

        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get => model; private set => model = value; }
        public int Power { get => power; private set => power = value; }
        public int Displacement { get => displacement; private set => displacement = value; }
        public string Efficiency { get => efficiency; private set => efficiency = value; }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
          this.Model = model;
          this.Power = power;
          this.Displacement = displacement;
            this.Efficiency = efficiency;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.Power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

            return sb.ToString();
        }
    }

}
