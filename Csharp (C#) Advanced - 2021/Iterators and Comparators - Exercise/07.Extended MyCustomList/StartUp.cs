
namespace Extended_MyCustomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class StartUp
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();
            ExecuteCommands(linkedList);
            PrinntResult(linkedList);
        }
        private static void PrinntResult(LinkedList<int> linkedList)
        {
            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }

        private static void ExecuteCommands(LinkedList<int> linkedList)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands > 0)
            {
                var command = Console.ReadLine().Split();
                var number = int.Parse(command[1]);

                switch (command[0])
                {
                    case "Add":
                        linkedList.AddFirst(number);
                        break;
                    case "Remove":
                        linkedList.Remove(number);
                        break;
                    default:
                        break;
                }

                numberOfCommands--;
            }
        }
    }
}
