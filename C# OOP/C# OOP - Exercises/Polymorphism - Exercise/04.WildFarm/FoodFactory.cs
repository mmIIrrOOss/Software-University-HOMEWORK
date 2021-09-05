

namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	public class FoodFactory
	{
		public Food CreateFood(string foodType, int quantity)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			Type type = assembly
				.GetTypes()
				.FirstOrDefault(t => t.Name == foodType);

			if (type == null)
			{
				throw new InvalidOperationException(ErrorMsgs.InvalidTypeMsg);
			}

			object[] ctorParams = new object[] { quantity };

			Food food = (Food)Activator.CreateInstance(type, ctorParams);
			return food;
		}
	}

}
