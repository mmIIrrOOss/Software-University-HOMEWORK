namespace CommandPattern.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Command_PostFix = "Command";

        public CommandInterpreter()
        {

        }

        public string Read(string args)
        {
            string[] commandTokens = args
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandTokens[0] + Command_PostFix;
            string[] commandArgs = commandTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(type);
            string result = commandInstance.Execute(commandArgs);
            return result;
        }
    }
}
