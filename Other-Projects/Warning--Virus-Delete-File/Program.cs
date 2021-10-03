
namespace Warning_VIRUS_Delete_Files
{
    using System;
    using System.IO;
    class Program
    {
        static void Main()
        {

            string diryctoryPath = Console.ReadLine();
            Console.WriteLine(GetDirectorySize(diryctoryPath, 0));
        }
        static double GetDirectorySize(string diryctoryPath, int identation)
        {
            string[] files = Directory.GetFiles(diryctoryPath);
            double sum = 0;
            string[] directories = Directory.GetDirectories(diryctoryPath);
            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"{new string(' ', identation + 3)}{directories[i]}");
                sum += GetDirectorySize(directories[i], identation + 5);
                Directory.Delete(directories[i]);
            }

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(files[i]);
                sum += fileInfo.Length;
                Console.WriteLine($"{new string('-', identation + 3)}{fileInfo.Name} ---> {fileInfo.Length} bytes.");
                File.Delete(files[i]);
            }
            return sum;
        }
    }
}
