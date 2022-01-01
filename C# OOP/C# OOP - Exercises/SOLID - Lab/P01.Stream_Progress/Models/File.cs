namespace P01.Stream_Progress.Models
{
    using Constrains;
    using Models;

    public class File : IResult
    {
        private string name;
        private int length;
        private int bytesSent;
        private StreamProgressInfo progressInfo;

        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get => name; private set => name = value; }

        public int Length { get => length; private set => length = value; }

        public int BytesSent { get => bytesSent; private set => bytesSent = value; }

    }
}
