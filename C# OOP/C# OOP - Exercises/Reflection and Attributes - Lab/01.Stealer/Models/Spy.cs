namespace Stealer.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string StealFieldInfo(string nameClass, params string[] nameFields)
        {
            Type classType = Type.GetType(nameClass);
            FieldInfo[] classFielnds = classType.GetFields(BindingFlags.Instance|
                BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {nameClass}");

            foreach (FieldInfo field in classFielnds.Where(f=>nameFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
