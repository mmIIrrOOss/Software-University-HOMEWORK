using System;
using System.Collections.Generic;

namespace WildFarm
{
	public abstract class Bird : Animal
	{
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; }

		public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]"; // f??
        }
    }
}
