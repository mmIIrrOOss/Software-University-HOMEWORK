namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = true)]

    public abstract class MyValidatorAttribute : Attribute
    {

        public abstract bool IsValid(object obj);

    }
}
