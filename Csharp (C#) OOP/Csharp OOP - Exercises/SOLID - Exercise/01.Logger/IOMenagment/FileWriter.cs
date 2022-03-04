namespace _01.Logger.IOMenagment
{
    using IOMenagment.Coonstrains;

    using System;
    using System.IO;

    public class FileWriter : IWriter
    {
        public FileWriter(string path)
        {
            this.FilePath = path;
        }

        public string FilePath { get; set; }

        public void Write(string value)
        {
            File.WriteAllText(this.FilePath,value);
        }

        public void WriteLine(string value)
        {
            File.WriteAllText(this.FilePath, value + Environment.NewLine);
        }
    }
}
