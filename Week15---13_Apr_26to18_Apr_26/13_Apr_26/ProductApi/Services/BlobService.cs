using Azure.Storage.Blobs;

namespace ProductApi.Services
{
    public class BlobService
    {
        private readonly string _connectionString;
        private readonly string _containerName = "images";

        public BlobService(IConfiguration config)
        {
            _connectionString = config["BlobConnection"]
                ?? throw new Exception("BlobConnection not configured in appsettings.json");
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var containerClient = new BlobContainerClient(_connectionString, _containerName);
            await containerClient.CreateIfNotExistsAsync();

            // Unique filename so uploads never overwrite each other
            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var blobClient = containerClient.GetBlobClient(uniqueFileName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, overwrite: true);

            // Returns the public Azure URL of the uploaded image
            return blobClient.Uri.ToString();
        }
    }
}