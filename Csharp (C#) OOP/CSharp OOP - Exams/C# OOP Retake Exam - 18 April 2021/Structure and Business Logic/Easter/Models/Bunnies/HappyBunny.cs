namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitialEnergy = 100;
        private const int DecreaseEnergy = 10;

        public HappyBunny(string name)
            : base(name, InitialEnergy)
        {

        }

        public override void Work()
        {
            this.Energy -= DecreaseEnergy;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
