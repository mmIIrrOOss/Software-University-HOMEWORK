namespace StudentSystem.IO.Contracts
{
    public interface IIoEngine
    {
        public string Read();

        public void Write(object obj);
    }
}
