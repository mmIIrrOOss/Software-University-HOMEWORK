namespace Gym.Core
{
    using Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            if (athleteType == "Boxer" && gym.GetType().Name == "BoxingGym")
            {
                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && gym.GetType().Name == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.InappropriateGym));
            }
            return string.Format(OutputMessages.SuccessfullyAdded, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }
            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }
            this.gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            double sum = gym.EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, sum);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            if (gym == null)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine($"{gym.Name} is a {gym.GetType().Name}:");
                if (gym.Athletes.Count == 0)
                {
                    sb.AppendLine($"Athletes: No athletes");
                    sb.AppendLine($"Equipment total count: {gym.Equipment.Count}");
                    sb.AppendLine($"Equipment total weight: {gym.EquipmentWeight} grams");
                }
                else
                {
                    sb.AppendLine($"Athletes: {string.Join(", ", gym.Athletes)}");
                    sb.AppendLine($"Equipment total count: {gym.Equipment.Count}");
                    sb.AppendLine($"Equipment total weight: {gym.EquipmentWeight} grams");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            int count = gym.Athletes.Count;
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
