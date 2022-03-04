namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private const int DecreasePower = 10;
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            this.Power -= DecreasePower;
            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }
    }
}
