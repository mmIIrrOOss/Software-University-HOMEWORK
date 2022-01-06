namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidatorAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;


        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.VlidateRange(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int)
            {
                int value = (int)obj;
                if (value < this.minValue || value > this.maxValue)
                {
                    return false;
                }
                return true;
            }
            else
            {
                throw new InvalidOperationException("Cannot validate given data type!");
            }
        }

        private void VlidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
