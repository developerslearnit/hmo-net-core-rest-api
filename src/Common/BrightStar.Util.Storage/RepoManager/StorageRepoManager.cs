using Azure.Storage.Blobs;
using BrightStar.Util.Storage.Azure.Interfaces;
using BrightStar.Util.Storage.Azure.Service;

namespace BrightStar.Util.Storage.RepoManager
{
    public class StorageRepoManager : IStorageRepoManager
    {
        private IAzureStorageService? _azureService;

        private BlobServiceClient _blobServiceClient;

        public StorageRepoManager(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public IAzureStorageService AzureStorage
        {
            get
            {
                if (_azureService == null)
                    _azureService = new AzureStorageService(_blobServiceClient);

                return _azureService;
            }
        }
    }
}
