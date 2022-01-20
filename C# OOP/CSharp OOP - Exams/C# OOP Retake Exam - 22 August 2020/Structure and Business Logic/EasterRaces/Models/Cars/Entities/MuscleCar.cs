namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Cubic_Centimeters = 5000;
        private const int Minimum_HorsePower = 400;
        private const int Maximum_HorsePower = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, Cubic_Centimeters, Minimum_HorsePower, Maximum_HorsePower)
        {
            
        }

    }
}
