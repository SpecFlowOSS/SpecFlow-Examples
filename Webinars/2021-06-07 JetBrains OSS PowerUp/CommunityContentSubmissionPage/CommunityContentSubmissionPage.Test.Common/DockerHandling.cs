using System;
using System.IO;
using System.Linq;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Polly;
using RestSharp;

namespace CommunityContentSubmissionPage.Test.Common
{
    public class DockerHandling
    {
        private static ICompositeService? _compositeService;

        public static void DockerComposeUp()
        {
            var dockerComposeFileName = FindDockerComposeFile();

            _compositeService = new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(dockerComposeFileName)
                .RemoveAllImages()
                .ForceRecreate()
                .RemoveOrphans()
                .Build()
                .Start();

            WaitForWebServer();
        }

        private static void WaitForWebServer()
        {
            var restClient = RestClientProvider.GetRestClient();

            var policy = Policy.HandleResult<bool>(r => !r)
                .WaitAndRetry(10, _ => TimeSpan.FromSeconds(10));

            policy.Execute(() =>
            {
                var restRequest = new RestRequest("/api/AvailableTypes", DataFormat.Json);

                var restResponse = restClient.Get(restRequest);

                return restResponse.IsSuccessful;
            });

        }

        public static void DockerComposeDown()
        {
            _compositeService?.Stop();
            _compositeService?.Dispose();
        }

        private static string FindDockerComposeFile()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var root = Path.Combine(currentDirectory, "..", "..", "..", "..", "..");

            return Directory.EnumerateFiles(root, "docker-compose.yml", SearchOption.AllDirectories).First();
        }


    }
}