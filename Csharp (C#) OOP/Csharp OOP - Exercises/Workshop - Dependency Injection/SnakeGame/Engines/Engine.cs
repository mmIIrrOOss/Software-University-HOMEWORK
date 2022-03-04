namespace SnakeGame.Engines
{
    using Dependency_Injection.Attributes;
    using SnakeGame.IO.Contracts;


    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
       // private readonly Snake snake;

        [Inject]
        public Engine(IReader reader,IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                writer.Write("Working...");
                //snake.DrawSnake();
            }
        }
    }
}
