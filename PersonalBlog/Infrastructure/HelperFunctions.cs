namespace PersonalBlog.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using static Constants.AppConstants.ImageContants;
    public static class HelperFunctions
    {
        public class ImageHelpers
        {
            public static string getFileExtension(IFormFile file)
            {
                return Path.GetExtension(file.FileName).ToLowerInvariant();
            }

            public static string ReturnUniqueFileName()
            {
                return Guid.NewGuid().ToString();
            }

            public static string ReturnFullFilePath(string rootFolderPath, string fileUniqueName)
            {
                return Path.Combine(rootFolderPath + ImageFolder, fileUniqueName);
            }
        }
    }
}
