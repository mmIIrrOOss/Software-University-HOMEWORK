namespace Stealer.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string StealFieldInfo(string className, params string[] nameFields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFielnds = classType.GetFields(BindingFlags.Instance |
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classFielnds.Where(f => nameFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeClass = Type.GetType(className);

            FieldInfo[] fieldInfo = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] methodInfos = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in publicMethods.Where(p => p.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(p => p.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeClass = Type.GetType(className);

            MethodInfo[] methodInfos = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base class: {typeClass.BaseType.Name}");

            foreach (var method in methodInfos)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            MethodInfo[] methodInfos = classType.GetMethods
                (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var method in methodInfos.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in methodInfos.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
