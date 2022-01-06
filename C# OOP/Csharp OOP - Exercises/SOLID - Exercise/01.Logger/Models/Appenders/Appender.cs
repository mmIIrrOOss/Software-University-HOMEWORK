namespace _01.Logger.Models.Appenders
{
    using Models.Constrains;
    using Models.Enumarations;

    public abstract class Appender : IAppender
    {
        protected int messagesAppend;

        public Appender(ILayout layout,Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString()}, " +
                $"Messages appended: {this.messagesAppend}";

        }
    }
}
