namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int[] dimetions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int x = dimetions[0];
            int y = dimetions[1];
            int[,] matrix = InitializeFiels(x, y);

            string command = Console.ReadLine();
            long sum = 0;
             
            while (command != "Let the Force be with you")
            {
                sum = ProcessCoordinates(matrix, command, sum);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long ProcessCoordinates(int[,] matrix, string command, long sum)
        {
            int[] ivoCoordinates = command
                                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

            int[] evilCoordinates = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            MoveEvilPlayer(matrix, evilCoordinates);
            sum = MoveIvoPlayer(matrix, sum, ivoCoordinates);
            return sum;
        }

        private static long MoveIvoPlayer(int[,] matrix, long sum, int[] ivoCoordinates)
        {
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (InsideTheFiels(ivoRow, ivoCol, matrix))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }


        private static void MoveEvilPlayer(int[,] matrix, int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (InsideTheFiels(evilRow,evilCol,matrix))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static bool InsideTheFiels(int row,int col,int[,] matrix )
        {
            bool inside = row >= 0 && row < matrix.GetLength(0)
                        && col >= 0 && col < matrix.GetLength(1);
            return inside;
        }

        private static int[,] InitializeFiels(int x, int y)
        {
            int[,] matrix = new int[x, y];

            int currentNum = 0;

            for (int row = 0; row < x; row++)
            {
                for (int col = 0; col < y; col++)
                {
                    matrix[row, col] = currentNum++;
                }
            }

            return matrix;
        }
    }
}
