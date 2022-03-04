namespace EgnHelper.Models.Contracts
{
    public interface IEgnValidator
    {
        public bool IsValid(string egn);
    }
}