namespace OnlineShop.Models.Products.Computers
{
    using Common.Constants;
    using Models.Products.Components;
    using Models.Products.Peripherals;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }



        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (!this.Components.Any())
                {
                    return base.OverallPerformance;
                }

                var componentsAveragePerformance = this.Components.Any()
                    ? this.Components.Average(c => c.OverallPerformance) : 0;

                return base.OverallPerformance + componentsAveragePerformance;
            }
        }

        public override decimal Price
            => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);


        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;
            if (this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral.GetType().Name;
            if (this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (this.Components.Count == 0 || this.components.All(x => x.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages
                    .NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral component = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (this.Components.Count == 0 || this.components.All(x => x.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages
                    .NotExistingComponent, peripheralType, this.GetType().Name, this.Id));
            }
            this.peripherals.Remove(component);
            return component;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($" {component}");
            }
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($" {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        public double AverageOverallPerformance()
        {
            if (this.peripherals.Count == 0)
            {
                return 0;
            }

            double average = this.peripherals.Average(x => x.OverallPerformance);
            return average;
        }
    }
}
