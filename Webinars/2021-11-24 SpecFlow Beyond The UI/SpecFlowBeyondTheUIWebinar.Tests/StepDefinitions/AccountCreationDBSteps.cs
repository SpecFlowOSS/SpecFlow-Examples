using Microsoft.Data.Sqlite;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using SpecFlowBeyondTheUIWebinar.Models;
using TechTalk.SpecFlow;

namespace SpecFlowBeyondTheUIWebinar.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "db")]
    public class AccountCreationDBSteps
    {
        private const string BASE_URL = "http://localhost:8080/parabank/services/bank";

        private RestClient client = default!;

        private string newAccountType = default!;
        private Customer customerJohn = default!;
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
            customerJohn = new Customer
            {
                FirstName = firstName,
                Id = 12212
            };
            fromAccountId = "12345";
        }

        [When(@"they open a new (checking|savings) account")]
        public void TheyOpenANewAccount(string accountType)
        {
            newAccountType = (accountType.Equals("checking") ? "0" : "1");

            RestRequest request = new RestRequest("/createAccount", Method.POST);

            request.AddQueryParameter("customerId", customerJohn.Id.ToString());
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
            int numberOfRows = 0;

            using (var connection = new SqliteConnection("Data Source=../../../DB/parabank.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT COUNT(*) FROM ACCOUNT WHERE id = $id
    ";
                command.Parameters.AddWithValue("$id", 12345);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        numberOfRows = reader.GetInt32(0);
                    }
                }
            }

            Assert.That(numberOfRows, Is.EqualTo(1));
        }
    }
}
