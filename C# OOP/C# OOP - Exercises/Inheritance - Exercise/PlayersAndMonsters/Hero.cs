
namespace PlayersAndMonsters
{
	using System;
	public class Hero
	{
		public Hero(string userName,int level)
		{
			this.UserName = userName;
			this.Level = level;
		}
		public string UserName
		{
			get
			{
				return this.userName;
			}
			set
			{
				this.userName = value;
			}
		}
		public int Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		private string userName;
		private int level;
		public override string ToString()
		{
			return $"Type: { this.GetType().Name} Username: { this.UserName} Level: { this.Level}";
		}
	}
}
