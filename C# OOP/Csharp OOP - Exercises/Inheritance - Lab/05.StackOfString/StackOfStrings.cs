

namespace CustomStack
{
 
    using System.Collections.Generic;
    
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            bool isEmty = this.Count == 0;
            return isEmty;
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
