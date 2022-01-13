namespace SnakeGame
{
    using Dependency_Injection.Attributes;
    using SnakeGame.IO.Contracts;

    public class Snake
    {
        private IWriter writer;

        [Inject]
        public Snake(IWriter writer)
        {
            this.writer = writer;
        }

        public void DrawSnake()
        {
            writer.Write("Snake");
        }
    }
}
