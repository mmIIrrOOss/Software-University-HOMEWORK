
namespace Implementing_Stack_and_Queue
{
    using System;
    using System.Linq;
    public class CustomList
    {
        public CustomList()
        {
            this.Items = new int[InitialCapacity];
        }
        private const int InitialCapacity = 2;
        private int[] Items;
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return Items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Items[index] = value;
            }
        }
        private void Resize()
        {
            int[] copy = new int[this.Items.Length * 2];
            for (int i = 0; i < this.Items.Length; i++)
            {
                copy[i] = this.Items[i];
            }
            this.Items = copy;
        }
        public void Add(int item)
        {
            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }
            this.Items[this.Count] = item;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int item = this.Items[index];
            this.Items[index] = default(int);
            this.Shift(index);

            this.Count--;
            if (this.Count <= this.Items.Length / 4)
            {
                this.Shrink();
            }
            return item;
        }

        private void Shrink()
        {
            int[] copy = new int[this.Items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.Items[i];
            }
            this.Items = copy;
        }
        private void Shift(int index)
        {
            for (int i = 0; i < this.Items.Length - 1; i++)
            {
                this.Items[i] = this.Items[i + 1];
            }
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.Items[i] = this.Items[i - 1];
            }
        }
        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Count == this.Items.Length)
            {
                this.Resize();
            }
            this.ShiftToRight(index);
            this.Items[index] = element;
            this.Count++;
        }
        public bool Contains(int element)
        {
            foreach (var item in this.Items)
            {
                if (item == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstiNdex, int secondIndex)
        {
            if (firstiNdex > this.Items.Count() || secondIndex > this.Items.Count())
            {
                throw new ArgumentOutOfRangeException();
            }
            var firstSwapElement = this.Items[firstiNdex];
            var secondSwapElement = this.Items[secondIndex];
            this.Items[firstiNdex] = secondSwapElement;
            this.Items[secondIndex] = firstSwapElement;
        }
    }
}
