
namespace SnakedGame
{
    using SnakeGame;
    public class Node
    {
        public Node(Position value)
        {
            this.Value = value;
        }
        public Position Value { get; set; }
        public Node NextNode { get; set; }
        public Node PreviousNode { get; set; }
    }
}
