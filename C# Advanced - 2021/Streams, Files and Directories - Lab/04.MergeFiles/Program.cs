
namespace _04.MergeFiles
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            var firstFile = new StreamReader("../../../FirstFile.txt");
            var secondtFile = new StreamReader("../../../SecondFile.txt");
            var thirdSaveFile = new StreamWriter("../../../ThirdFile.txt");
            using (firstFile)
            {
                string currentLine = firstFile.ReadLine();
                using (secondtFile)
                {
                    string currentLineTwo = secondtFile.ReadLine();
                    while (currentLine != null && currentLineTwo != null)
                    {
                        if (currentLine != currentLineTwo)
                        {
                            thirdSaveFile.WriteLine(currentLine);
                            thirdSaveFile.WriteLine(currentLineTwo);
                            continue;
                        }
                        thirdSaveFile.WriteLine(firstFile);
                    }
                }
            }
            thirdSaveFile.Close();
        }
    }
}
