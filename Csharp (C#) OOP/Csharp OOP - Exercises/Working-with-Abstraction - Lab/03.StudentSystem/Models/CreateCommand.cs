namespace StudentSystem.Models
{
    using System;
    using Contracts;

    public class CreateCommand : ICommands
    {
        public void Execute(string[] args, StudentsData studentsData)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            studentsData.Add(name, age, grade);
        }
    }
}
