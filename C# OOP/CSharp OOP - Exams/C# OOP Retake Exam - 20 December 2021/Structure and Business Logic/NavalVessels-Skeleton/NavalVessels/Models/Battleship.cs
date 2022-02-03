namespace NavalVessels.Models
{
    using Contracts;

    using System;

    public class Battleship : Vessel, IBattleship
    {


        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {

        }

        public bool SonarMode { get; private set; } = false;

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public void ToggleSonarMode()
        {

            if (this.SonarMode == false)
            {
                this.SonarMode = true;
            }
            else
            {
                this.SonarMode = true;
            }

            if (this.SonarMode == true)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            string sonarMode = this.SonarMode == true ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $"Sonar mode: {sonarMode}";
        }
    }
}
