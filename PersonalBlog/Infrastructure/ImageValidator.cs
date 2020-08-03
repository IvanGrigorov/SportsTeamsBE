namespace PersonalBlog.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Linq;
    using static Constants.Validation.Image;
    public static class ImageValidator
    {
        public static bool CheckIfFileIsBigger(IFormFile file)
        {
            if (file.Length > ImageMaxSize)
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfFileIsForbidden(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !ImageExtensions.Contains(ext))
            {
                return true;
            }
            return false;
        }
    }
}
