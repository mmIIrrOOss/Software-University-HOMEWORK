

namespace CustomStack
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StackOfStrings : Stack<string>
	{
		public bool isEmpty()
		{
			return this.Count == 0;
		}
		public void AddRange(IEnumerable<string> values)
		{
			foreach (var value in values)
			{
				this.Push(value);
			}
		}
	}
}
