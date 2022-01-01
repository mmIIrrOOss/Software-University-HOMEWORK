namespace P03.Detail_Printer
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Constrains;

    class StartUp
    {
        static void Main()
        {
            IEmployee employee = new Employee("Niki");
            List<string> infoManager = new List<string>()
            {
                "Name",
                "Age",
                "Salary",
                "Adress"
            };

            IEmployee manager = new Manager("Miro", infoManager);
            Console.WriteLine(employee);
            Console.WriteLine(manager);
        }
    }
}
