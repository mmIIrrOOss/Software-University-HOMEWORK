namespace _01.Logger.Models.Files
{
    using _01.Logger.Common;
    using _01.Logger.Models.Constrains;
    using _01.Logger.Models.Enumarations;

    using System;
    using System.IO;
    using System.Linq;

    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

     
        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path => this.pathManager.CurrentFilePath;

        public long Size => this.CalculateSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;
            string formatMessage = string.Format
                                    (format, dateTime.ToString(GlobalConstans.DateTimeFirmat),
                                    level.ToString(),
                                    message);
            return formatMessage;
        }

        private long CalculateSize()
        {
            string fileText = File.ReadAllText(this.Path);
            return fileText.ToCharArray().Sum(c=>c);
        }
    }
}
