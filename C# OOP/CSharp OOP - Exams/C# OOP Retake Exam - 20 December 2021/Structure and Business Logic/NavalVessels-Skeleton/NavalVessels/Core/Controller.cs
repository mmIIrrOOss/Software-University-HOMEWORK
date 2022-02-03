namespace NavalVessels.Core
{
    using Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            if (captain.FullName is null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            IVessel vessel = this.vessels.Models.FirstOrDefault(x => x.Name == selectedVesselName);
            if (vessel is null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel.Captain!= null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            captain.AddVessel(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel atackVessel = this.vessels.Models.FirstOrDefault(x => x.Name == attackingVesselName);
            IVessel difendVessel = this.vessels.Models.FirstOrDefault(x => x.Name == defendingVesselName);
            if (atackVessel == null || difendVessel == null)
            {
                return $"Vessel {atackVessel.Name} could not be found.";
            }
            if (atackVessel.ArmorThickness <= 0 || difendVessel.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {atackVessel.Name} cannot attack or be attacked.";
            }
            atackVessel.Attack(difendVessel);
            atackVessel.Captain.IncreaseCombatExperience();
            difendVessel.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {difendVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (this.captains.Contains(captain))
            {
                return $"Captain {fullName} is already hired.";
            }
            this.captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;
            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return "Invalid vessel type.";
            }
            if (this.vessels.Models.Contains(vessel))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            this.vessels.Add(vessel);
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.Models.FirstOrDefault(x => x.Name == vesselName);
            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.Models.FirstOrDefault(x=>x.Name==vesselName);
            if (vessel is null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else if (vessel.GetType().Name == "Battleship")
            {
                vessel = vessel as Battleship;
                
                return $"Battleship {vessel.Name} toggled sonar mode.";
            }
            return $"Submarine {vessel.Name} toggled submerge mode.";
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.Models.FirstOrDefault(x => x.Name == vesselName);
            return vessel.ToString();
        }
    }
}
