namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Cubic_Centimeters = 3000;
        private const int Minimum_HorsePower = 250;
        private const int Maximum_HorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, Cubic_Centimeters, Minimum_HorsePower, Maximum_HorsePower)
        {

        }
    }
}
