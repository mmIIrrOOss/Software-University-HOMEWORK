namespace StudentSystem.Models
{
    using Models.Contracts;
    using System.Collections.Generic;
    using IO.Contracts;

    public class StudentSystem 
    {
        private StudentsData studentsData;
        private Dictionary<string, ICommands> commands;
        private IIoEngine ioEngine1;

        public StudentSystem(IIoEngine ioEngine)
        {
            this.studentsData = new StudentsData();
            this.commands = new Dictionary<string, ICommands>();
            this.commands.Add("Create", new CreateCommand());
            this.commands.Add("Show", new ShowCommand(ioEngine));
            this.ioEngine1 = ioEngine;
        }

        public void ParseCommands()
        {
            while (true)
            {
                string[] args = this.ioEngine1.Read().Split();
                string commandType = args[0];
                if (this.commands.ContainsKey(commandType))
                {
                    var command = this.commands[commandType];
                    command.Execute(args,this.studentsData);  
                }
                else if (commandType == "Exit")
                {
                    return;
                }
            }
        }
    }
}