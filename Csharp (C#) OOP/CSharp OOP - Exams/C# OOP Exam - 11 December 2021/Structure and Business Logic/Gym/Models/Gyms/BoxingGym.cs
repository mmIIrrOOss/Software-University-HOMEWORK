namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int Capacity = 15;

        public BoxingGym(string name) 
            : base(name, Capacity)
        {
        }
    }
}
