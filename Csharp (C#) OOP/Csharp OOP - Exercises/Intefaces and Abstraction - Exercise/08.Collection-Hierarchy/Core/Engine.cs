namespace _08.Collection_Hierarchy.Core
{
    using Interfaces;
    using IO.Interfaces;
    using System.Text;
    using Models;
    using System;

    public class Engine : IEngine
    {
        private IAddCollection<string> addCollection;
        private IAddRemoveCollection<string> addRemoveCollection;
        private IMyList<string> myList;
        private StringBuilder sb;

        public Engine()
        {
            this.addCollection = new AddCollection<string>();
            this.addRemoveCollection = new AddRemoveCollection<string>();
            this.myList = new MyList<string>();
            this.sb = new StringBuilder();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split();
            this.FillCollection(ref input, this.addCollection);
            this.FillCollection(ref input, this.addRemoveCollection);
            this.FillCollection(ref input, this.myList);

            int numberOfRemoveElement = int.Parse(Console.ReadLine());
            this.RemoveOperation(numberOfRemoveElement, this.addRemoveCollection);
            this.RemoveOperation(numberOfRemoveElement, this.myList);

            Console.WriteLine(this.sb.ToString().TrimEnd());
        }
        private void RemoveOperation(int numberOfItem, IAddRemoveCollection<string> collection)
        {
            while (numberOfItem > 0)
            {
                var removeElement = collection.Remove();
                this.sb.Append($"{removeElement} ");
                numberOfItem--;
            }
            this.sb
                .Remove(this.sb.Length - 1, 1)
                .AppendLine();
        }
        private void FillCollection(ref string[] input, IAddCollection<string> collection)
        {
            foreach (var str in input)
            {
                var index = collection.Add(str);
                this.sb.Append($"{index} ");
            }

            this.sb
                .Remove(this.sb.Length - 1, 1)
                .AppendLine();
        }



    }

}


