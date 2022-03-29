namespace _04.AddMinion.Models
{
    public class Villain
    {
        private const string DefaultEvilnessFactor = "Evil";

        public Villain(string name)
            :this(name,DefaultEvilnessFactor)
        {

        }

        public Villain(string name,string evilnessFactor)
        {
            this.Name = name;
            this.EvillnessFactor = evilnessFactor;
        }

        public string Name { get; set; }

        public string EvillnessFactor { get; set; }

    }
}
