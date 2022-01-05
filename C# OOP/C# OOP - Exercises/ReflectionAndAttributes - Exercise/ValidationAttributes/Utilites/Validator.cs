namespace ValidationAttributes.Utilites
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidatorAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidatorAttribute)
                    .Cast<MyValidatorAttribute>()
                    .ToArray();

                foreach (MyValidatorAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
