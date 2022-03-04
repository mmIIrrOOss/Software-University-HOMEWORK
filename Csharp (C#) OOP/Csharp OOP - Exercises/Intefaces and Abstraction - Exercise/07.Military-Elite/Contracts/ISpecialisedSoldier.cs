namespace _07.Military_Elite.Contracts
{
    using _07.Military_Elite.Enumerations;
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
