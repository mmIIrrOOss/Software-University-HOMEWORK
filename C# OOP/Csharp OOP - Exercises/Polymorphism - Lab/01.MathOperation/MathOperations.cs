namespace Operations
{
    public class MathOperations
    {
        public int Add(int firstNumber,int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }
        public double Add(double firstNumber, double secondNumber,double thirdNumber)
        {
            double sum = firstNumber + secondNumber + +thirdNumber;
            return sum;
        }
        public decimal Add(decimal firstNumber, decimal secondNumber, decimal thirdNumber)
        {
            decimal sum = firstNumber + secondNumber + +thirdNumber;
            return sum;
        }
    }
}
