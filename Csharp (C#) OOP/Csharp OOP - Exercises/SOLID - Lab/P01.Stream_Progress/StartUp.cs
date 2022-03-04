namespace P01.Stream_Progress
{
    using System;
    using Models;
    using Models.Constrains;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IResult file = new File("Text.txt", 5, 20);
            IResult music = new Music("Adele", "30", 5, 10);

            List<StreamProgressInfo> results = new List<StreamProgressInfo>();
            StreamProgressInfo fileProgressInfo = new StreamProgressInfo(file);
            StreamProgressInfo musicProgressInfo = new StreamProgressInfo(music);

            results.Add(fileProgressInfo);
            results.Add(musicProgressInfo);

            foreach (var currentProgressInfo in results)
            {
                Console.WriteLine($"{currentProgressInfo.GetType().Name} --- Progres info: {currentProgressInfo.CalculateCurrentPercent()}%");
            }
        }
    }
}
