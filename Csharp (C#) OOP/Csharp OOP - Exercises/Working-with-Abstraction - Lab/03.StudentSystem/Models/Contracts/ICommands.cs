namespace StudentSystem.Models.Contracts
{
    public interface ICommands
    {
        public void Execute(string[] args, StudentsData studentsData);
    }
}
