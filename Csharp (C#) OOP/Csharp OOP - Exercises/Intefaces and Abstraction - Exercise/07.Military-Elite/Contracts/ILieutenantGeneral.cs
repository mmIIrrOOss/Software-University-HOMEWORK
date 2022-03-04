namespace _07.Military_Elite.Contracts
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPrivate(ISoldier @private);
    }
}
