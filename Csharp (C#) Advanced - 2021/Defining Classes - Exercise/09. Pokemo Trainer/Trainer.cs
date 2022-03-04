
namespace _09._Pokemo_Trainer
{
	using System.Collections.Generic;
	public class Trainer
	{
		public Trainer(string name)
		{
			this.Name = name;
			this.Badjes = 0;
			this.Pokemons = new List<Pokemon>();
		}
		public string Name { get; set; }
		public int Badjes { get; set; }
		public List<Pokemon> Pokemons { get; set; }

		public override string ToString()
		{
			return $"{this.Name} {this.Badjes} {this.Pokemons.Count}";
		}
		public void GiveBadge()
		{
			this.Badjes++;
		}
	}
}
