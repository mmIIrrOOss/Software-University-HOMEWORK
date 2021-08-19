using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
	public class Engine
	{
		public Engine(string model , int power)
		{
			this.Model = model;
			this.Power = power;
		}
		public string Model { get; set; }
		public int Power { get; set; }
		public int Displacement { get; set; }
		public string Efficiency { get; set; }
	}
}
