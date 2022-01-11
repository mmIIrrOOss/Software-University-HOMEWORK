namespace _01.Singleton
{
    using System;

    class StartUp
    {
        

        static void Main(string[] args)
        {
            var db = SingleDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington, D.C."));
            var db2 = SingleDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
        }
    }
}
