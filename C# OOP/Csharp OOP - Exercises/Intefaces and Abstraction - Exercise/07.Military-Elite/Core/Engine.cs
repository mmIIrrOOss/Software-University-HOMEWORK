namespace _07.Military_Elite.Engine
{
    using _07.Military_Elite.Contracts;
    using _07.Military_Elite.Engine.IO.Contracts;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using _07.Military_Elite.Models;
    using _07.Military_Elite.Exceptions;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] arguments = command.
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = arguments[0];
                int id = int.Parse(arguments[1]);
                string firstName = arguments[2];
                string lastName = arguments[3];

                ISoldier soldier = null;
                if (soldierType == "Private")
                {
                    soldier = AddPrivate(arguments, id, firstName, lastName);

                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddLieutenantGeneral(arguments, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(arguments[4]);
                    string copr = arguments[5];
                    try
                    {
                        soldier = AddEngineer(arguments, id, firstName, lastName, salary, copr);

                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                }
                else if (soldierType == "Commando")
                {

                    decimal salary = decimal.Parse(arguments[4]);
                    string corps = arguments[5];

                    try
                    {
                        soldier = CreateCommando(arguments, id, firstName, lastName, salary, corps);
                    }
                    catch
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(arguments[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if (soldier!=null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
        private static ISoldier CreateCommando(string[] arguments, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            Commando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArguments = arguments.Skip(6).ToArray();

            for (int i = 0; i < missionArguments.Length; i += 2)
            {
                try
                {
                    string codeName = missionArguments[i];
                    string state = missionArguments[i + 1];
                    Mission missionToAdd = new Mission(codeName, state);
                    commando.AddMission(missionToAdd);
                }
                catch
                {
                    continue;
                }
            }

            soldier = commando;
            return soldier;
        }
        private static ISoldier AddEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string copr)
        {
            ISoldier soldier;
            Engineer engineer = new Engineer(id, firstName, lastName, salary, copr);
            string[] repears = cmdArgs.Skip(6).ToArray();
            for (int i = 0; i < repears.Length; i += 2)
            {
                string partName = repears[i];
                int hourseWork = int.Parse(repears[i + 1]);
                IRepeair repeair = new Repear(partName, hourseWork);
                engineer.AddRepeair(repeair);
            }
            soldier = engineer;
            return soldier;
        }

        private ISoldier AddLieutenantGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);

            }
            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}
