namespace StudentSystem.IO.Contracts
{
    public interface IWriter
    {
        public void Write(object obj);

        public void WriteLine(object obj);
    }
}
