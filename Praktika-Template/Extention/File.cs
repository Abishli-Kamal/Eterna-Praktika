using Microsoft.AspNetCore.Http;

namespace Praktika_Template.Extention
{
    public static class File
    {
        public static bool IsImages(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }
        public static bool IsGreater(this IFormFile file, int mb)
        {
            return file.Length > mb * 1024 * 1024;
        }
        public static bool IsOkey(this IFormFile file,int mb)
        {
           return file.ContentType.Contains("image") && file.Length > mb * 1024 * 1024;
        }
    }
}
