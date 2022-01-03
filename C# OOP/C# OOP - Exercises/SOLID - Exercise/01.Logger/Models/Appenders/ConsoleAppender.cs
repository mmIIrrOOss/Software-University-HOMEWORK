namespace _01.Logger.Models.Appenders
{
    using _01.Logger.Common;
    using _01.Logger.IOMenagment;
    using _01.Logger.IOMenagment.Coonstrains;
    using _01.Logger.Models.Enumarations;

    using Constrains;
    using System;
    
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout,Level level)
            :base(layout,level)
        {
            this.writer = new ConsoleWriter();
        }


        public override void Append(IError error)
        {
            string format = this.Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatingString = string.Format(format, dateTime.ToString(GlobalConstans.DateTimeFirmat)
                ,level.ToString()
                ,message);
            this.writer.WriteLine(formatingString);
            this.messagesAppend++;
        }
    }
}
