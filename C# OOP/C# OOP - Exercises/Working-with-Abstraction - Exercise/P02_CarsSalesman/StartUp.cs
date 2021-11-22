namespace P02_CarsSalesman
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IProgramEngine program = new ProgramEngine();
            program.Run();
        }
    }
}
