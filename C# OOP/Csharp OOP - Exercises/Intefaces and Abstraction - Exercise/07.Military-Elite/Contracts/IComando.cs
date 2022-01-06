namespace _07.Military_Elite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        public void AddMission(IMission mission);
    }
}
