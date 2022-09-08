using Microsoft.AspNetCore.StaticFiles;

namespace BrightStar.Util.Storage
{
    public static class StorageHelpers
    {
        private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();

        public static string GetContentType(this string fileName)
        {
            if (!Provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }


        public static bool IsImage(this string fileName)
        {

            return Provider.TryGetContentType(fileName, out var contentType)
                && contentType.StartsWith("image/");
        }

        public static bool IsAllowedImageFile(this string fileName)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            return allowedExtensions.Any(ext => fileName.EndsWith(ext, System.StringComparison.OrdinalIgnoreCase));

        }


        private static string[] allowedExt = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };


        public static string[] AllowedImageFiles
        {
            get
            {
                return allowedExt;
            }
        }




    }
}
