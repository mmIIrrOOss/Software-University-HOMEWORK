namespace Stealer.Models
{
    public class Hacker
    {
        public string username = "SecurityGod82";

        private string password = "MySuperSecretPassword";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        private string Id { get; set; }

        public int BankAccountBalance { get; private  set; }

        public void DownloadAllBankAccountsInTheWorld()
        {

        }

    }
}
