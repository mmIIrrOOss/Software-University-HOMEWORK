namespace _01.Logger.Models.Error
{
    using _01.Logger.Models.Constrains;
    using _01.Logger.Models.Enumarations;

    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime {get;}
                                   
        public string Message  {get;}
                                   
        public Level Level { get; }
    }
}
