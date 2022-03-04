using System;

namespace GodzilavsKingKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSecond = double.Parse(Console.ReadLine());
            double metters = double.Parse(Console.ReadLine());
            double timeSecond = double.Parse(Console.ReadLine());

            double timeSwiming = metters * timeSecond;
            double delay = metters / 15;
            double plus = Math.Floor(delay) * 12.5;
            double totalTime = timeSwiming + plus;

            if (recordSecond > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                double difference = totalTime - recordSecond;
                Console.WriteLine($"No, he failed! He was {difference:f2} seconds slower.");
            }
        }
    }
}
