using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main()
        {
            var reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                int lineCounter = 1;
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (lineCounter % 2 != 0)
                        {
                            var regex = new Regex(@"[-,.!@]");
                            line = regex.Replace(line, "@");
                            var array = line.Split().Reverse();
                            writer.WriteLine(string.Join(" ",array));
                        }
                        line = reader.ReadLine();
                        lineCounter++;
                    }
                }
            }
        }
    }
}
