using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Drivers
{
    public class BlobLogger
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _containerClient;

        public BlobLogger()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(connectionString))
                _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task CreateContainer()
        {
            if (_blobServiceClient == null)
                return;

            string containerName =
                Assembly.GetExecutingAssembly().GetName().Name + DateTime.Now.ToString("s");

            containerName = containerName
                .Replace(":", "-")
                .Replace(".", "-")
                .ToLower();

            var response = await _blobServiceClient.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);
            _containerClient = response.Value;
        }

        public async Task<Uri> LogImage(byte[] imageData)
        {
            if (_containerClient == null)
                return null;

            BlobClient blobClient = _containerClient.GetBlobClient(
                Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".png");

            using MemoryStream uploadFileStream = new MemoryStream(imageData);
            var headers = new BlobHttpHeaders() { ContentType = "image/png" };
            await blobClient.UploadAsync(uploadFileStream, headers);

            uploadFileStream.Close();

            return blobClient.Uri;
        }

    }

}
