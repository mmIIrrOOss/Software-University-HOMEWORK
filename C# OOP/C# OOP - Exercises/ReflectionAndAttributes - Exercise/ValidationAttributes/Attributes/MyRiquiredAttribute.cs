namespace ValidationAttributes.Attributes
{
    public class MyRiquiredAttribute : MyValidatorAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return true;
        }
    }
}
