namespace _01.Logger.Core
{
    using _01.Logger.Common;
    using _01.Logger.IOMenagment.Coonstrains;
    using _01.Logger.Models.Constrains;
    using _01.Logger.Models.Enumarations;
    using _01.Logger.Models.Error;

    using Constrains;
    using System;
    using System.Globalization;

    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
       

        public Engine(ILogger logger,IReader reader,IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine())!="END")
            {
                string[] errorArgs = command.Split('|');
                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];


                bool isLevelValid = Enum.TryParse
                    (typeof(Level), levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstans.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;
                bool isDateTimeValid = DateTime.TryParseExact
                    (dateTimeStr, GlobalConstans.DateTimeFirmat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);
                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstans.InvalidDateTimeFormat);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
