namespace _08.Collection_Hierarchy.Models
{
    using Interfaces;
    using System.Collections.Generic;
    public class AddCollection<T> : IAddCollection<T>
    {
        protected List<T> Data { get; set; }

        public AddCollection()
        {
            this.Data = new List<T>();
        }

        public virtual int Add(T element)
        {
            this.Data.Add(element);
            return this.Data.Count - 1;
        }
    }
}
