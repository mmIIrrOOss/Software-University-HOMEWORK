namespace _08.Collection_Hierarchy.Core.IO.Interfaces
{
    using System;

    public interface IWriter
    {
        public void Write(string value);

        public void WriteLine(string value);
    }
}
