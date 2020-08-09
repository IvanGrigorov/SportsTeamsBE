namespace PersonalBlog.Features.Galleries
{
    using Microsoft.AspNetCore.Http;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Galleries.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGalleryService
    {
        public Task UploadImage(IFormFile file, GalleryMapperObject galleryMapperObject);

        public Task UploadImageInDB(IFormFile file, string uniqueFilePath, GalleryMapperObject galleryMapperObject);

        public Task UploadImageInFileStorage(IFormFile file, string filePath);

        public Task<bool> ObtainMultipleFiles(IEnumerable<IFormFile> files, GalleryMapperObject galleryMapperObject);

        public bool ValidateMultupleFiles(IEnumerable<IFormFile> files);

        public Task<IEnumerable<Gallery>> ReturnFilesForDeletion(GalleryMapperObject galleryMapperObject);

        public void DeleteImageFromFileStorage(IEnumerable<Gallery> files);

        public Task DeleteImageFromDB(IEnumerable<Gallery> files);

    }
}
