using System;
using System.IO;
using System.Linq;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using NUnit.Framework;
using Polly;
using RestSharp;

namespace CommunityContentSubmissionPage.Test.Common
{
    public class DockerHandling
    {
        private static ICompositeService? _compositeService;

        public static void DockerComposeUp()
        {
            try
            {
                if (_compositeService != null)
                    return;

                var dockerComposeFileName = FindDockerComposeFile();

                WriteLine("Starting Docker");
                _compositeService = new Builder()
                    .UseContainer()
                    .UseCompose()
                    .FromFile(dockerComposeFileName)
                    .RemoveAllImages()
                    .ForceRecreate()
                    .RemoveOrphans()
                    .Build()
                    .Start();

                WriteLine("Docker started; waiting for application");

                WaitForWebServer();

                WriteLine("Application started or timed out");
            }
            catch (Exception e)
            {
                WriteLine(e.ToString());
                throw;
            }
        }

        private static void WriteLine(string message)
        {
            Console.WriteLine(message);
            TestContext.WriteLine(message);
        }

        private static void WaitForWebServer()
        {
            var restClient = RestClientProvider.GetRestClient();

            var policy = Policy.HandleResult<bool>(r => !r)
                .WaitAndRetry(20, _ => TimeSpan.FromSeconds(10));

            policy.Execute(() =>
            {
                var restRequest = new RestRequest("/api/AvailableTypes", DataFormat.Json);

                var restResponse = restClient.Get(restRequest);

                WriteLine($"Check if App is online: {restResponse.IsSuccessful}");

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