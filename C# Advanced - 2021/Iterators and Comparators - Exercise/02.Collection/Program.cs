
namespace ListyIterator
{
    using System;
    using System.Linq;
    using System.Text;
    class Program
    {
        static void Main()
        {
            var readData = Console.ReadLine().Split();
            ListyIterator<string> lisIterator;
            if (readData.Length > 1)
            {
                lisIterator = new ListyIterator<string>(readData.Skip(1));
            }
            else
            {
                lisIterator = new ListyIterator<string>();
            }
            Console.WriteLine(CommandsExecution(lisIterator));
        }
        private static string CommandsExecution(ListyIterator<string> collection)
        {
            var sb = new StringBuilder();
            var cmdArgs = Console.ReadLine().Split();

            while (cmdArgs[0] != "END")
            {
                try
                {
                    switch (cmdArgs[0])
                    {
                        case "Move":
                            sb.AppendLine(collection.Move().ToString());
                            break;
                        case "Print":
                            sb.AppendLine(collection.Print());
                            break;
                        case "HasNext":
                            sb.AppendLine(collection.HasNext().ToString());
                            break;
                        case "PrintAll":
                            foreach (var item in collection)
                            {
                                sb.Append($"{item} ");
                            }

                            sb.Remove(sb.Length - 1, 1);
                            sb.AppendLine();
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);
                }

                cmdArgs = Console.ReadLine().Split();
            }

            return sb.ToString().Trim();
        }
    }
}
