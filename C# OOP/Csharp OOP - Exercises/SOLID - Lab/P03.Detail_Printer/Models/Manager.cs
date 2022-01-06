namespace P03.Detail_Printer.Models
{
    using System;
    using System.Collections.Generic;
    using Constrains;

    public class Manager : Employee, IEmployee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Documents: " + Environment.NewLine +
                string.Join(Environment.NewLine, Documents);
        }
    }
}
