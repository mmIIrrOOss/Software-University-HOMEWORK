using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayOfHolidey = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string evaluation = Console.ReadLine();

            double priceForNight = 0;
            double discount = 0;
            if (typeOfRoom == "room for one person")
            {
                priceForNight = 18.00;
            }
            else if (typeOfRoom == "apartment")
            {
                priceForNight = 25.00;
                if (dayOfHolidey <= 10)
                {
                    discount = 0.30;
                }
                else if (dayOfHolidey >= 10 && dayOfHolidey <= 15)
                {
                    discount = 0.35;
                }
                else
                {
                    discount = 0.50;
                }
            }
            else if (typeOfRoom == "president apartment")
            {
                priceForNight = 35.00;
                if (dayOfHolidey <= 10)
                {
                    discount = 0.10;
                }
                else if (dayOfHolidey >= 10 && dayOfHolidey <= 15)
                {
                    discount = 0.15;
                }
                else
                {
                    discount = 0.20;
                }
            }
            double totalPrice = (dayOfHolidey - 1) * priceForNight;
            totalPrice -= totalPrice * discount;
            if (evaluation == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"{totalPrice:f2}");



            //switch (typeOfRoom)
            //{
            //    case "room for one person":
            //      priceForNight= 18.00;
            //        break;
            //    case "apartment":
            //       priceForNight = 25.00;
            //        if (dayOfHolidey < 10)
            //        {
            //            discount = 0.30;
            //        }
            //        else if (dayOfHolidey >= 10 && dayOfHolidey <= 15)
            //        {
            //            discount = 0.35;
            //        }
            //        else
            //        {
            //            discount = 0.50;
            //        }
            //        break;
            //        break;
            //    case "president apartment":
            //            priceForNight = 35.00;
            //        if (dayOfHolidey > 10)
            //        {
            //            discount = 0.10;
            //        }
            //        else if (dayOfHolidey >= 10 && dayOfHolidey <= 15)
            //        {
            //            discount = 0.15;
            //        }
            //        else
            //        {
            //            discount = 0.20;
            //        }

            //        break;
            //    default:
            //        break;
            //}


            //    if (evaluation=="positive")
            //    {
            //        totalPrice += totalPrice * 0.25;
            //    }
            //    else
            //    {
            //        totalPrice -= totalPrice * 0.10;
            //    }
            //    Console.WriteLine($"{totalPrice:f2}");
            //}
        }
    }
}
