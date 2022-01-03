namespace _01.Logger.Factories
{
    using System;
    using Models.Constrains;
    using System.Reflection;
    using System.Linq;

    using Common;

    public class LayoutFactory
    {
        

        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals(layoutTypeStr
                ,StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException
                    (GlobalConstans.InvalidLayoutType);
            }

            object[] ctorArgs = new object[] { };
            ILayout layout = (ILayout) 
                Activator.CreateInstance(layoutType,ctorArgs);

            return layout;
        }
    }
}
