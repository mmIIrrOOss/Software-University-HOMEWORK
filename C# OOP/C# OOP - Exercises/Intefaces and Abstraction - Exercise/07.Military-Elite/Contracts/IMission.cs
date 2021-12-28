
namespace _07.Military_Elite.Contracts
{
    using _07.Military_Elite.Enumerations;
    public interface IMission
    {
        public string CodeName { get; }

        public State State { get; }

        public void CompleteMission();
    }
}
