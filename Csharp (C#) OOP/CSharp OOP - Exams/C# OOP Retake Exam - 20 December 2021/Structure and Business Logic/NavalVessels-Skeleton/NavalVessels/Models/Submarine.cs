namespace NavalVessels.Models
{
    using Contracts;

    using System;

    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode { get; private set; } = false;

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {

            if (this.SubmergeMode == true)
            {
                this.SubmergeMode = false;
            }
            else
            {
                this.SubmergeMode = false;
            }
            if (this.SubmergeMode == true)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            string sonarMode = this.SubmergeMode == false ? "OFF" :"ON";
            return base.ToString() + Environment.NewLine + $"Submerge mode: {sonarMode}";
        }
    }
}
