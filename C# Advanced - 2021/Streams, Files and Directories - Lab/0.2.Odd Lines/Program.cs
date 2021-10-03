
namespace _0._2.Odd_Lines
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {

            using (var reader = new StreamReader("../../../input.txt"))
            {
                string lines = reader.ReadLine();
                int count = 1;
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (lines != null)
                    {
                        writer.WriteLine($"{count}. {lines}");
                        lines = reader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
