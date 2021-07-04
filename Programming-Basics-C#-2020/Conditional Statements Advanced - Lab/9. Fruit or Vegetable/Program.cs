using System;

namespace FruitandVegetable
{
    class Program
    {
        static void Main(string[] args)
        {


            string name = Console.ReadLine();

            switch (name)
            {
                case "banana":
                case "apple":
                case "kiwi":
                case "cherry":
                case "lemon":
                case "grapes":
                    Console.WriteLine("fruit");
                    break;
                case "tomato":
                case "cucumber":
                case "pepper":
                case "carrot":
                    Console.WriteLine("vegetable");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }




            //if (name == "banana"||name=="apple"||name=="kiwi"||name=="cherry"||name=="lemon"||name=="grapes")
            //{
            //    Console.WriteLine("fruit");
            //}
            //else if (name=="tomato"||name=="cucumber"||name=="pepper"||name=="carrot")
            //{
            //    Console.WriteLine("vegetable");
            //}
            //else
            //{
            //    Console.WriteLine("uknown");
            //}
        }
    }
}
