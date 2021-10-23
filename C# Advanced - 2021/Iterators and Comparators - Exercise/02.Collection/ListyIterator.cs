

namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class ListyIterator<T> : IEnumerable<T>
    {
        private const int currentIndex = 0;
        private int index;
        private readonly List<T> data;
        public ListyIterator()
        {

            this.data = new List<T>();
            this.index = currentIndex;
        }
        public ListyIterator(IEnumerable<T> collectData)
        {

            this.data = new List<T>(collectData);
        }
        public bool Move()
        {
            if (this.index < this.data.Count - 1)
            {
                this.index++;
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool HasNext() => this.index < this.data.Count - 1;

        public T Print()
        {
            if (this.data.Count < 0)
            {
                throw new ArgumentException("Invalid operation!");
            }
            return this.data[this.index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private class ListyIteratorEnumerator : IEnumerator<T>
        {
            private readonly List<T> data;

            private int currentIndex;

            public ListyIteratorEnumerator(List<T> data)
            {
                this.Reset();
                this.data = data;
            }

            public T Current => this.data[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.data.Count;

            public void Reset() => this.currentIndex = -1;
        }
    }
}
