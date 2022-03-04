namespace _01.Logger.Models.Constrains
{
    using Enumarations;

    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);

    }
}
