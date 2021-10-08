
namespace SnakedGame
{
    using System;
    using System.Collections.Generic;

    public  class LinkedListt
    {

        public Node Head { get; set; }
        public Node Tail { get; set; }
        public bool IsReserved { get; set; }
        public void Reserve() 
        {
            var oldHead = Head;
            Head = Tail;
            Tail = oldHead;
        }
        public void ForEach(Action<Node> action)
        {
            Node currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.NextNode;
            }

        }
        public void ReverseForEach(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.PreviousNode;
            }

        }
        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }
        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.NextNode = Head;
                Head.PreviousNode = newHead;
                Head = newHead;
            }
        }
        public void AddLast(Node newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.PreviousNode = Tail;
                Tail.NextNode = newTail;
                Tail = newTail;
            }

        }
        public Node RemoveFirst()
        {
            var oldHead = this.Head;
            Head = this.Head.PreviousNode;
            Head.NextNode = null;
            return oldHead;
        }
        public Node RemoveLast()
        {
            var oldTail = this.Tail;
            Tail = this.Tail.PreviousNode;
            Tail.NextNode = null;
            return oldTail;
        }
        public Node Peek()
        {
            return this.Head;
        }
        public void PrintList()
        {
            this.ForEach(node => Console.WriteLine(node.Value));
        }
        public void ReversePrintList()
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.PreviousNode;
            }
        }

    }
}
