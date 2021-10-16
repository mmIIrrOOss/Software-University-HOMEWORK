
namespace _06.Zip_and_Extract
{
    using System;
    using System.IO.Compression;
    class Program
    {
        static void Main()
        {
            ZipFile.CreateFromDirectory(@"D:\ZipFileDemo", @"D:\myZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\myZipFile.zip", @"D:\SoftUni");
        }
    }
}
