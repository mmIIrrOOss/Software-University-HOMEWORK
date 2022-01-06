namespace _01.Logger
{
    using _01.Logger.Common;
    using _01.Logger.Factories;
    using _01.Logger.IOMenagment.Coonstrains;
    using _01.Logger.Models.Constrains;
    using _01.Logger.Models.Enumarations;
    using System.Collections.Generic;
    using System;
    using Models;
    using _01.Logger.IOMenagment;
    using _01.Logger.Models.PathManagment;
    using _01.Logger.Models.Files;
    using _01.Logger.Core.Constrains;
    using _01.Logger.Core;

    public class StratUp
    {
     

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);
            ILogger logger = SetUpLogger(n, reader, writer, file,layoutFactory,appenderFactory);

            IEngine engine = new Engine(logger,reader,writer);
            engine.Run();

        }
        private static ILogger SetUpLogger(int appendersCnt, IReader reader, 
            IWriter writer,IFile file,LayoutFactory layoutFactory,AppenderFactory appenderFactory)
        {


            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCnt; i++)
            {
                string[] appendArgs = reader.ReadLine().Split();
                string appendType = appendArgs[0];
                string layout = appendArgs[1];

                bool hasError = false;
                Level level = ParseLevel(appendArgs, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout1 = layoutFactory.CreateLayout(layout);

                    IAppender appender = appenderFactory.
                        CreateAppender(appendType, layout1, level,file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            ILogger logger = new Logger(appenders);
            return logger;
        }

        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level level = Level.INFO;
            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);
                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstans.InvalidLevelType);
                    hasError = true;
                }

                level = (Level)enumParsed;
            }
            return level;
        }
    }
}
