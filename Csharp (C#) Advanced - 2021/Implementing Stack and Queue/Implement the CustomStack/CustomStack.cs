namespace Implement_the_CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CustomStack
    {
        public CustomStack()
        {
            this.count = 0;
            this.Items = new int[InitialCapacity];
        }
        public int Count => this.count;

        private const int InitialCapacity = 4;
        private int[] Items;
        private int count;
        public void Push(int element)
        {
            if (this.Items.Length == this.Count)
            {
                var nextItems = new int[this.Items.Length * 2];
                for (int i = 0; i < this.Items.Length; i++)
                {
                    nextItems[i] = this.Items[i];
                }
                this.Items = nextItems;
            }
            this.Items[this.count] = element;
            count++;
        }
        public int Pop(int element)
        {
            if (this.Items.Length==0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var lastIndex = this.count - 1;
            int last = this.Items[lastIndex];
            this.count--;
            return last;
        }
        public int Peek()
        {
            if (this.Items.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var lastElement = this.Items[this.Items.Length - 1];
            return lastElement;
        }
        public void ForEach(Action<object>  action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.Items[i]);
            }
        }
    }
}
