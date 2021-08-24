

namespace Animals
{
	using System;
	public class Tomcat : Cat
	{
		public Tomcat(string name,int age, string gender="Male") 
			: base(name, gender, age)
		{

		}
		public override string ProduceSound()
		{
			return "MEOW";
		}
	}
}
