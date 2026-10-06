using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace RentalCall.Services
{
    public class BlobStorageService
    {
        public BlobStorageService() 
        { 

        }

        public Uri GenerateSasUrl(string blobName)
        {
            string connectionString = "<your-storage-connection-string>";
            string containerName = "audiofiles";

            // Create client
            BlobServiceClient serviceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Generate SAS token valid for 1 hour
            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "b", // b = blob
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };

            // Read permission
            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            // Build SAS URI
            Uri sasUri = blobClient.GenerateSasUri(sasBuilder);

            return sasUri;
        }
    }
}
