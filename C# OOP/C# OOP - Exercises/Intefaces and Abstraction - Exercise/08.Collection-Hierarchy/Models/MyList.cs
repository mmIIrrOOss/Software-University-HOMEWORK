namespace _08.Collection_Hierarchy.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;

    public class MyList<T> : AddRemoveCollection<T>,IMyList<T>
    {
        private const int RemoveIndex = 0;
        public IReadOnlyCollection<T> Used
        {
            get
            {
                return this.Used as IReadOnlyCollection<T>;
            }

        }
        public override T Remove()
        {
            var firstElement = this.Data.First();
            this.Data.RemoveAt(RemoveIndex);
            return firstElement;
        }
    }
}
