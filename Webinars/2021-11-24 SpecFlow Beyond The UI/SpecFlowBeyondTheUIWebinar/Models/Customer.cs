namespace SpecFlowBeyondTheUIWebinar.Models
{
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Account> Accounts { get; set; } = default!;

        public void CreateNewAccount(Account newAccount)
        {
            Accounts.Add(newAccount);
        }
    }
}
