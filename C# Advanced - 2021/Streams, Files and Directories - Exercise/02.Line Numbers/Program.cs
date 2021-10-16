using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] text = File.ReadAllLines("../../../input.txt");
            StringBuilder sb = new StringBuilder();

            using (StreamWriter file = new StreamWriter("../../../output.txt"))
            {
                int count = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    int countLetter = CountOfLetters(text[i]);
                    int countSymbol = CountOfSymbol(text[i]);
                    count++;
                    string connectAllText = string.Format($"Line {count++}: {text[i]} ({countLetter})({countSymbol})");
                    sb.AppendLine(connectAllText);
                }
                file.WriteLine(sb);
            }

        }
        static int CountOfLetters(string line)
        {
            int countLetter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    countLetter++;
                }
            }
            return countLetter;
        }
        static int CountOfSymbol(string line)
        {
            char[] arr = { '-', ',', '.', '!', '?', '\'' };
            int countcountSymbol = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (arr.Contains(line[i]))
                {
                    countcountSymbol++;
                }
            }
            return countcountSymbol;
        }
    }
}
