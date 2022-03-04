using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\b([A-Z][a-z]+) {1}[A-Z][a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchednames = Regex.Matches(names, patern);

            Console.WriteLine(string.Join(" ", matchednames));
        }
    }
}