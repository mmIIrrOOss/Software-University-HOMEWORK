using System.Collections.Generic;

namespace MilitaryElite
{
	public interface ICommando
	{
		ICollection<Mission> Missions { get; }
	}
}