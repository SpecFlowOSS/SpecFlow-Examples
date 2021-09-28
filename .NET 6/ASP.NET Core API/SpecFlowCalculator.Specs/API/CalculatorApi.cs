using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace SpecFlowCalculator.Specs.API
{
    public class CalculatorApi
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        private readonly RestClient _client;

        public CalculatorApi()
        {
            _client = new RestClient("https://localhost:5001");

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
        }

        public async Task<int> AddAsync()
        {
            var request = new RestRequest("Calculator/Add").AddObject(this);

            var response =  await _client.GetAsync<CalculatorResponse>(request);

            return response.Result;
        }

        public async Task<int> SubtractAsync()
        {
            var request = new RestRequest("Calculator/Subtract").AddObject(this);

            var response = await _client.GetAsync<CalculatorResponse>(request);

            return response.Result;
        }

        public async Task<int> MultiplyAsync()
        {
            var request = new RestRequest("Calculator/Multiply").AddObject(this);

            var response = await _client.GetAsync<CalculatorResponse>(request);

            return response.Result;
        }

        public async Task<int> DivideAsync()
        {
            var request = new RestRequest("Calculator/Divide").AddObject(this);

            var response = await _client.GetAsync<CalculatorResponse>(request);

            return response.Result;
        }
    }

    internal sealed class CalculatorResponse
    { 
        public int Result { get; set; }
    }
}