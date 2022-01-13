namespace Dependency_Injection.Modules
{
    using Dependency_Injection.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;

        private IDictionary<Type, object> instances;


        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public Type GetMapping(Type currebtInterface, object attribute)
        {
            IDictionary<string, Type> currentImplementation = this.implementations[currebtInterface];

            Type type = null;

            if (attribute is Inject)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException("No available mapping for class: " + currebtInterface.FullName);
                }
            }
            else if (attribute is Named)
            {
                Named named = attribute as Named;

                string dependencyName = named.Name;
                return currentImplementation[dependencyName];
            }



            return type;
        }

        public object GetInstance(Type parameter)
        {
            this.instances.TryGetValue(parameter, out object value);
            return value;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
            {
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
    }
}
