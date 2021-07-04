using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
    class Program
    {
        static void Main(string[] args)
        {

            string city = Console.ReadLine();
            double commisions = double.Parse(Console.ReadLine());
            double totalCommisions = 0;
            if (city == "Sofia")
            {
                if (commisions <= 500)
                {
                    totalCommisions = commisions * 0.05;

                }
                else if (commisions >= 500 && commisions <= 1000)
                {
                    totalCommisions = commisions * 0.07;
                }
                else if (commisions >= 1000 && commisions <= 10000)
                {
                    totalCommisions = commisions * 0.08;
                }
                else if (commisions > 10000)
                {
                    totalCommisions = commisions * 0.12;
                }
                else if (commisions >= 0)
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (commisions <= 500)
                {
                    totalCommisions = commisions * 0.045;
                }
                else if (commisions >= 500 && commisions <= 1000)
                {
                    totalCommisions = commisions * 0.075;
                }
                else if (commisions >= 1000 && commisions <= 10000)
                {
                    totalCommisions = commisions * 0.10;
                }
                else if (commisions > 10000)
                {
                    totalCommisions = commisions * 0.13;
                }
                else if (commisions >= 0)
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (commisions <= 0)
                {
                    Console.WriteLine("error");
                    return;
                }
                else if (commisions <= 500)
                {
                    totalCommisions = commisions * 0.055;
                }
                else if (commisions >= 500 && commisions <= 1000)
                {
                    totalCommisions = commisions * 0.08;
                }
                else if (commisions >= 1000 && commisions <= 10000)
                {
                    totalCommisions = commisions * 0.12;
                }
                else if (commisions > 10000)
                {
                    totalCommisions = commisions * 0.145;
                }

            }
            else
            {
                Console.WriteLine("error");
                return;
            }
            Console.WriteLine($"{totalCommisions:f2}");

        }
    }
}
