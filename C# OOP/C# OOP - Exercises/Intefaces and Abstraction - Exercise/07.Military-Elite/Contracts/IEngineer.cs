namespace _07.Military_Elite.Contracts
{
    using System.Collections.Generic;
    public  interface IEngineer:ISpecialisedSoldier
    {
        IReadOnlyCollection <IRepeair> Ripears { get; }

        void AddRepeair(IRepeair repeair);
    }
}
