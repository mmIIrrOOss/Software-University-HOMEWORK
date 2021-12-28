namespace _09.Explicit_Interfaces
{
    using System;
    using _09.Explicit_Interfaces.Models;
    using _09.Explicit_Interfaces.Intefaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var splitCommand = command.Split();

                IPerson person = new Citizen(splitCommand[0]);
                Console.WriteLine(((IPerson)person).GetName());

                IResident resident = new Citizen(splitCommand[0]);
                Console.WriteLine(((IResident)person).GetName());
            }
        }
    }
}
