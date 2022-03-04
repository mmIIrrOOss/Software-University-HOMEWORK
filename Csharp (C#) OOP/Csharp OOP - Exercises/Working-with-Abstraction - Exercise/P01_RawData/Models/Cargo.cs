namespace P01_RawData.Models
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargotype)
        {
           this.CargoWieght = cargoWeight;
           this.CargoType = cargotype;
        }
        public int CargoWieght { get; }
        public string CargoType { get; }
    }
}
