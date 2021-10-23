
namespace Extended_MyCustomList
{
    using System;

    public partial class DoublyLinkedList<T>
    {

        public DoublyLinkedList(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }

        public DoublyLinkedList<T> Next { get; set; }

        public DoublyLinkedList<T> Prev { get; set; }

        public override string ToString()
        {
            return this.Item.ToString();
        }
    }
}
