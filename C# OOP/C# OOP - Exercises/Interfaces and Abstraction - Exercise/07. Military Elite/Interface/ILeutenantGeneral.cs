namespace MilitaryElite
{
	using System.Collections.Generic;
	internal interface ILeutenantGeneral
	{
		ICollection<Private> Privates { get; }
	}
}