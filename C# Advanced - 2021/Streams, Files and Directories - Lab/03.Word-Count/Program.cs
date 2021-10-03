
namespace _03.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, int> saveResult = new SortedDictionary<string, int>();
            string inputWords = File.ReadAllText("../../../text.txt");
            string[] words = inputWords.Split(new string[] {  Environment.NewLine,"," }, StringSplitOptions.None);
            Regex regex = new Regex(@"[A-Za-z]+");
            using (var reader = new StreamReader("../../../words.txt"))
            {
                string arrayWords = reader.ReadLine();// izrechenie
                while (arrayWords != null)
                {
                    foreach (Match item in regex.Matches(arrayWords))
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            string compare = item.Value.ToLower();
                            string word = words[i].ToLower();
                            if (word.Contains(compare) && !(saveResult.ContainsKey(item.Value)))
                            {
                                saveResult.Add(item.ToString(), 1);
                            }
                            else if (word.Contains(compare))
                            {
                                saveResult[item.ToString()]++;
                            }
                        }
                    }
                    arrayWords = reader.ReadLine();
                }
                foreach (var item in saveResult.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} -" +
                        $" {item.Value}");
                }
            }

        }

    }
}
