namespace P04.Recharge.Models
{
    using Constrains;

    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity { get { return this.capacity; } }

        public int CurrentPower 
        { 

            get { return this.currentPower; } 
            private set { this.currentPower = value; } 
        }

        public override int Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = this.currentPower;
            }

            base.Work(hours);
            return this.currentPower -= hours;
        }

        public int Recharge()
        {
            return this.currentPower = this.capacity;
        }
        public override string ToString()
        {
            return base.ToString() + $"Current power: {this.currentPower}";
        }
    }
}