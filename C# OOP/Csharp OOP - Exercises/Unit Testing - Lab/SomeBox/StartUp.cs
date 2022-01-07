namespace SomeBox
{
    using System;
    using EgnHelper.Models;
    using EgnHelper.Enums;
    class SatrtUp
    {
        public static void Main()
        {
           
            string egn = "8032056031";
            var egnExtractor = new EgnInformationExtractor();
            EgnInformation egnInformation = egnExtractor.Extract(egn);
            Console.WriteLine(egnInformation);

        }
    }
}
