using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Interfaces.Avon
{
    public interface IFileService
    {
        void UploadFile(List<IFormFile> files, string subDirectory);

        List<string> UploadFiles(List<IFormFile> files, string subDirectory);
        string UploadFile(IFormFile file, string subDirectory);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        string SizeConverter(long bytes);
    }
}
