using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
	public class Car
	{
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, string color, int weight) : this(model, engine, color)
        {
            this.Weight = weight;
        }
        public string Model { get; set; }
		public Engine Engine { get; set; }
		public double Weight { get; set; }
		public string Color { get; set; }
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append($"{this.Model}:").AppendLine();
			sb.Append($"  {this.Engine.Model}:").AppendLine();
			sb.Append($"    Power: {this.Engine.Power}").AppendLine();
			sb.Append(this.Engine.Displacement == 0 ? $"    Displacement: n/a" : $"    Displacement: {this.Engine.Displacement}").AppendLine();
			sb.Append($"    Efficiency: {this.Engine.Efficiency}").AppendLine();
			sb.Append(this.Weight == 0 ? $"  Weight: n/a" : $"  Weight: {this.Weight}").AppendLine();
			sb.Append($"  Color: {this.Color}");

			return $"{sb}";
		}
	}
}
