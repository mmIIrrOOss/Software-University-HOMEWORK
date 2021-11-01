
namespace Sum_Of_Coins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            var availableCoins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            var targetSum = int.Parse(Console.ReadLine());
            try
            {
                var selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //TheProgram();

        }
        public static void TheProgram()
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            List<int> coinsReturn = new List<int>();
            int change = 0;
            coins = coins.OrderByDescending(x => x).ToArray();
            while (change < n)
            {
                for (int i = 0; i < coins.Length; i++)
                {
                    if (change + coins[i] <= n)
                    {
                        change += coins[i];
                        coinsReturn.Add(coins[i]);
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", coinsReturn));
        }
        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins
                .OrderByDescending(c => c)
                .ToList();

            var chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[coinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinToTake = remainingSum / currentCoinValue;

                if (numberOfCoinToTake > 0)
                {
                    chosenCoins[currentCoinValue] = numberOfCoinToTake;

                    currentSum += currentCoinValue * numberOfCoinToTake;
                }

                coinIndex++;

            }

            if (currentSum == targetSum)
            {
                return chosenCoins;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
