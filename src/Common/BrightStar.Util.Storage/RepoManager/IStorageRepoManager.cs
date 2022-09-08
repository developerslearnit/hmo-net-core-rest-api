using BrightStar.Util.Storage.Azure.Interfaces;

namespace BrightStar.Util.Storage.RepoManager
{
    public interface IStorageRepoManager
    {
        IAzureStorageService AzureStorage {get;}
    }
}
