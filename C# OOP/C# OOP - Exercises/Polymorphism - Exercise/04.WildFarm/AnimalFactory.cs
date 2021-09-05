
namespace WildFarm
{
	using System;
	using System.Collections.Generic;
	public class AnimalFactory
	{
        public Animal Create(string type, string name, double weight, string[] args)
        {
            Animal animal = null;

            if (type == "Hen" || type == "Owl")
            {
                double wingSize = double.Parse(args[0]);

                if (type == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);
                }
                else
                {
                    throw new InvalidOperationException(ErrorMsgs.InvalidTypeMsg);
                }
            }
            else if (type == "Mouse" || type == "Dog" || type == "Cat" || type == "Tiger")
            {
                string livingRegion = args[0];

                if (args.Length == 1)
                {
                    if (type == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else if (type == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else
                    {
                        throw new InvalidOperationException(ErrorMsgs.InvalidTypeMsg);
                    }
                }
                else
                {
                    string breed = args[1];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        throw new InvalidOperationException(ErrorMsgs.InvalidTypeMsg);
                    }
                }
            }

            return animal;
        }
    }
}
