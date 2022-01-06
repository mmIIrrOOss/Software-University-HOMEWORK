namespace _01.Logger.Factories
{
    using _01.Logger.Common;
    using _01.Logger.Models.Appenders;
    using _01.Logger.Models.Constrains;
    using _01.Logger.Models.Enumarations;

    using System;

    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }

        public IAppender CreateAppender(string appenderType, ILayout layout,
            Level level, IFile file = null)
        {
            IAppender appender;
            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstans.InvalidAppenderType);
            }
            return appender;
        }
    }
}
