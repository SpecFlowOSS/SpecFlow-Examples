namespace SpecFlowBeyondTheUIWebinar.Models
{
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Id { get; set; }
        public List<Account> Accounts { get; set; }

        public void CreateNewAccount(Account newAccount)
        {
            Accounts.Add(newAccount);
        }
    }
}
