namespace StudentSystem.Core
{
    using Models;
    using Contracts;

    public class Engine : IEngine
    {
        public void Run()
        {
            var studentSystem = new StudentSystem(new ConsoleIoEngine());
            studentSystem.ParseCommands();
        }
    }
}
