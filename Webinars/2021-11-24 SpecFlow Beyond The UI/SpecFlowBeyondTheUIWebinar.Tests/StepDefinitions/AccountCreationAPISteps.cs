using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowBeyondTheUIWebinar.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowBeyondTheUIWebinar.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "api")]
    public class AccountCreationAPISteps
    {
        private const string BASE_URL = "http://localhost:8080/parabank/services/bank";

        private RestClient client = default!;

        private string newAccountType = default!;
        private string customerId = default!;
        private string fromAccountId = default!;

        private int newAccountNumber;

        [BeforeScenario]
        public void CreateTheRestClient()
        {
            client = new RestClient(BASE_URL);
            client.AddDefaultHeader("Accept", "application/json");
        }

        [Given(@"user (.*) is ready to open a new account")]
        public void UserIsReadyToOpenANewAccount(string firstName)
        {
            customerId = "12212";
            fromAccountId = "12345";
        }

        [When(@"they open a new (checking|savings) account")]
        public void TheyOpenANewAccount(string accountType)
        {
            newAccountType = (accountType.Equals("checking") ? "0" : "1");

            RestRequest request = new RestRequest("/createAccount", Method.POST);

            request.AddQueryParameter("customerId", customerId);
            request.AddQueryParameter("newAccountType", newAccountType);
            request.AddQueryParameter("fromAccountId", fromAccountId);

            IRestResponse response = client.Execute(request);

            Account newAccount = new JsonDeserializer()
                .Deserialize<Account>(response);

            newAccountNumber = newAccount.Id;
        }

        [Then(@"the new account is included in their list of accounts")]
        public void TheNewAccountIsIncludedInTheirListOfAccounts()
        {
            RestRequest request = new RestRequest($"/customers/{customerId}/accounts", Method.GET);

            IRestResponse response = client.Execute(request);

            List<Account> accounts = new JsonDeserializer()
                .Deserialize<List<Account>>(response);

            List<Account> accountsWithTheNewAccountNumber =
                accounts.FindAll(account => account.Id == newAccountNumber);

            Assert.That(accountsWithTheNewAccountNumber.Count, Is.EqualTo(1));
        }
    }
}
