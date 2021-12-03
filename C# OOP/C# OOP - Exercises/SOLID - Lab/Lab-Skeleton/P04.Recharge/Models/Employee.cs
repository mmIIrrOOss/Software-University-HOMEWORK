namespace P04.Recharge.Models
{
    using Constrains;
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id)
            : base(id)
        {
        }

        public string Sleep()
        {
            return $"I sleeping...";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Sleep()}";
        }
    }
}
