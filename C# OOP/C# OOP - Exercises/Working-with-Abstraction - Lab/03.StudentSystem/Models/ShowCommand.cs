namespace StudentSystem.Models
{
    using System;
    using Contracts;
    using IO.Contracts;

    public class ShowCommand : ICommands
    {
        private readonly IIoEngine ioEngine;

        public ShowCommand(IIoEngine ioEngine)
        {
            this.ioEngine = ioEngine;
        }

        public void Execute(string[] args, StudentsData studentsData)
        {
            var name = args[1];
            Student student = studentsData.Find(name);
            if (student != null)
            {
                this.ioEngine.Write(student.ToString());
            }
        }
    }
}
