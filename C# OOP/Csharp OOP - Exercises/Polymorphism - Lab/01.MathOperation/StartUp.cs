namespace Operations
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mathOperations = new MathOperations();
            int firstResult =  mathOperations.Add(1,2);
            double secondResult = mathOperations.Add(1.2, 2.3, 3.3);
            decimal thirdResult = mathOperations.Add(3.3m, 2.3m, 5.2m);

            Console.WriteLine(firstResult);
            Console.WriteLine(secondResult);
            Console.WriteLine(thirdResult);
        }
    }
}
