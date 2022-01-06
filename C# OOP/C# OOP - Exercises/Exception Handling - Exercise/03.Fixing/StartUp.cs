namespace _03.Fixing
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
            };

            try
            {
                for (int i = 0; i <= weekDays.Length; i++)
                {
                    Console.WriteLine(weekDays[i]);
                }
                Console.WriteLine();
            }
            catch (IndexOutOfRangeException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
