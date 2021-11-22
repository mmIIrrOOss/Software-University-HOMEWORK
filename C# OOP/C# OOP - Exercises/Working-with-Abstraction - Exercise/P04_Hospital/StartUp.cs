using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        private const int MaxBedsDepartment = 60;
        public static void Main()
        {
            Dictionary<string, HashSet<string>> department = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> docctors = new Dictionary<string, HashSet<string>>();

            string command = ReadData(department, docctors);
            string outputCommand = PrintAndOrderingData(department, docctors);
        }

        private static string ReadData(Dictionary<string, HashSet<string>> department, Dictionary<string, HashSet<string>> docctors)
        {
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                string[] args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var departamentName = args[0];
                string doctorFirstName = args[1];
                var doctorLecondName = args[2];
                var doctorFullName = doctorFirstName + " " + doctorLecondName;
                var patientsName = args[3];

                if (!department.ContainsKey(departamentName))
                {
                    department[departamentName] = new HashSet<string>();
                }
                if (!docctors.ContainsKey(doctorFullName))
                {
                    docctors[doctorFullName] = new HashSet<string>();
                }
                if (department[departamentName].Count >= MaxBedsDepartment)
                {
                    continue;
                }
                AddPatientsforDepartment(department, departamentName, patientsName);
                AddPatientsForDoctors(docctors, doctorFullName, patientsName);
            }

            return command;
        }

        private static string PrintAndOrderingData(Dictionary<string, HashSet<string>> department, Dictionary<string, HashSet<string>> docctors)
        {
            string outputCommand;
            while ((outputCommand = Console.ReadLine()) != "End")
            {
                string[] args = outputCommand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                int countOfSearchElement = args.Length;
                switch (countOfSearchElement)
                {
                    case 1:
                        string seachedDepartment = args[0];
                        if (department.ContainsKey(seachedDepartment))
                        {
                            department[seachedDepartment].ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        break;
                    case 2:
                        string searchedDoctor = args[0] + " " + args[1];
                        if (docctors.ContainsKey(searchedDoctor))
                        {
                            docctors[searchedDoctor].OrderBy(x => x)
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        else
                        {
                            string currentDepartmen = args[0];
                            int searchedRoom = int.Parse(args[1]);
                            department[currentDepartmen]
                                .Skip((searchedRoom * 3) - 3)
                                .Take(3)
                                .OrderBy(x => x)
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        break;
                }
            }

            return outputCommand;
        }

        private static void AddPatientsForDoctors(Dictionary<string, HashSet<string>> docctors, string doctorFullName, string patientsName)
        {
            docctors[doctorFullName].Add(patientsName);
        }

        private static void AddPatientsforDepartment(Dictionary<string, HashSet<string>> department, string departamentName, string patientsName)
        {
            department[departamentName].Add(patientsName);
        }
    }
}
