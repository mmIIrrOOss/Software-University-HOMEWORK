namespace P04.Recharge.Models
{
    public abstract class Worker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual int Work(int hours)
        {
            return this.workingHours += hours;
        }
        public override string ToString()
        {
            return $"Id: {this.id} Working hours:{this.workingHours}";
        }
    }
}