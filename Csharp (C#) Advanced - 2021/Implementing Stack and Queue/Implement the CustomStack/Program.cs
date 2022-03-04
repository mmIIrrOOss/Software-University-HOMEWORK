
namespace Implement_the_CustomStack
{
    using System;
    class Program
    {
        static void Main()
        {
            var customStack = new CustomStack();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Pushhh: {i}");
                customStack.Push(i);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Pooppp: {i}");
                customStack.Pop(i);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Peek method is workkk {customStack.Peek()}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Custom stack is ForEach method:");
            customStack.ForEach(x => Console.WriteLine($"Is Foreach method ---- {x}"));
        }
    }
}
