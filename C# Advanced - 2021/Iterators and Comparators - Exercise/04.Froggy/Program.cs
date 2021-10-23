
namespace _04.Froggy
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            PlayTheGame();
        }
        private static void PlayTheGame()
        {
            var stoneValues = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stones = new Lake<int>(stoneValues);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
