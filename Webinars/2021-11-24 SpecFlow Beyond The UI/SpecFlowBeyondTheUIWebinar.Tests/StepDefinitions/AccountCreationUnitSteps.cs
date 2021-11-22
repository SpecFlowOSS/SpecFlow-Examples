using NUnit.Framework;
using SpecFlowBeyondTheUIWebinar.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowBeyondTheUIWebinar.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "unit")]
    public class AccountCreationUnitSteps
    {
        private Customer customer = default!;
        private Account account = default!;

        [Given(@"user (.*) is ready to open a new account")]
        public void UserIsReadyToOpenANewAccount(string firstName)
        {
            customer = new Customer
            {
                FirstName = firstName,
                LastName = "Smith",
                Id = 12212,
                Accounts = new List<Account>()
            };
        }

        [When(@"they open a new (checking|savings) account")]
        public void TheyOpenANewAccount(string accountType)
        {
            account = new Account
            {
                Id = 12345,
                CustomerId = customer.Id,
                AccountType = accountType,
                Balance = 0
            };

            customer.Accounts.Add(account);
        }

        [Then(@"the new account is included in their list of accounts")]
        public void TheNewAccountIsIncludedInTheirListOfAccounts()
        {
            List<Account> accountsWithTheNewAccountNumber =
                customer.Accounts.FindAll(account => account.Id == 12345);

            Assert.That(accountsWithTheNewAccountNumber.Count, Is.EqualTo(1));
        }
    }
}
