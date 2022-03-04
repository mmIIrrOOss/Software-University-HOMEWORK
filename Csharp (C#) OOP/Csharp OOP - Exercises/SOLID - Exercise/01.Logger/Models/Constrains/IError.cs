namespace _01.Logger.Models.Constrains
{
    using _01.Logger.Models.Enumarations;

    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
