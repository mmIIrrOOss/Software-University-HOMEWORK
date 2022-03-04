using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int group = int.Parse(Console.ReadLine());
        string groupType = Console.ReadLine();
        string dayOfWeek = Console.ReadLine();

        double price = 0;
        double totalPrice = 0;

        switch (groupType)
        {
            case "Students":
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 8.45;
                        break;
                    case "Saturday":
                        price = 9.80;
                        break;
                    case "Sunday":
                        price = 10.46;
                        break;
                }

                if (29 < group)
                {
                    totalPrice = group * price * 0.85;
                }

                else
                {
                    totalPrice = group * price;
                }
                break;
            case "Business":
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 10.90;
                        break;
                    case "Saturday":
                        price = 15.60;
                        break;
                    case "Sunday":
                        price = 16.00;
                        break;
                }

                if (99 < group)
                {
                    totalPrice = (group - 10) * price;
                }

                else
                {
                    totalPrice = group * price;
                }
                break;

            case "Regular":
                switch (dayOfWeek)
                {
                    case "Friday":
                        price = 15.00;
                        break;
                    case "Saturday":
                        price = 20.00;
                        break;
                    case "Sunday":
                        price = 22.50;
                        break;
                }

                if (9 < group && group < 21)
                {
                    totalPrice = group * price * 0.95;
                }

                else
                {
                    totalPrice = group * price;
                }
                break;
        }

        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}





