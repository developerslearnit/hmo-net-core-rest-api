using BrightStar.Util.Storage.Models;
using Microsoft.AspNetCore.Http;

namespace BrightStar.Util.Storage.Azure.Interfaces
{
    public interface IAzureStorageService
    {
        Task<AzureUploadResponseModel> UploadAsync(string filePath,string container);

        Task<List<AzureUploadResponseModel>> UploadAsync(List<IFormFile> files, string container);

        Task<AzureUploadResponseModel> UploadAsync(IFormFile file, string container);

        Task<byte[]> DownloadAsync(string fileName, string container);
    }
}
