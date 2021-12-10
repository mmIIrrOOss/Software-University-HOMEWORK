namespace PlayersAndMonsters.Models
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string name, int level)
        {
            UserName = name;
            Level = level;
        }
        public string UserName { get => username; set => username = value; }
        public int Level { get => level; set => level = value; }
        public override string ToString()
        {
            return $"Type: {GetType().Name} " +
                $"Username: {username} Level: {Level}";
        }

    }
}
