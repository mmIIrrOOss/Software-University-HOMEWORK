namespace _01.Logger.Models.Appenders
{
    using _01.Logger.IOMenagment;
    using _01.Logger.IOMenagment.Coonstrains;
    using _01.Logger.Models.Enumarations;

    using Models.Constrains;

    public class FileAppender : Appender
    {

        private readonly IWriter writer;

        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;
            this.writer = new FileWriter(this.File.Path);
        }
        public IFile File { get; set; }

        public override void Append(IError error)
        {
            string formatted = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formatted);
            this.messagesAppend++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
