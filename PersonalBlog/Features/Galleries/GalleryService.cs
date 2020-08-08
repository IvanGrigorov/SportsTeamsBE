namespace PersonalBlog.Features.Galleries
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Galleries.Models;
    using PersonalBlog.Infrastructure;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using static Infrastructure.HelperFunctions.ImageHelpers;


    public class GalleryService : BaseApiService, IGalleryService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public GalleryService(PersonalBlogDbContext personalBlogDbContext, IWebHostEnvironment webHostEnvironment) : base(personalBlogDbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteFilesForProject(GalleryMapperObject galleryMapperObject)
        {
            var files = await this.personalBlogDbContext
                .Gallery
                .Where(g => g.ProjectId == galleryMapperObject.ProjectId && g.ArticleId == galleryMapperObject.ArticleId)
                .ToListAsync();

            this.DeleteImageFromFileStorage(files);
            await this.DeleteImageFromDB(files);

        }

        public async Task<bool> ObtainMultipleFiles(IEnumerable<IFormFile> files, GalleryMapperObject galleryMapperObject)
        {
            if (!this.ValidateMultupleFiles(files))
            {
                return false;
            }
            foreach (var file in files)
            {
                await this.UploadImage(file, galleryMapperObject);
            }
            return true;
        }

        public async Task UploadImageInDB(IFormFile file, string uniqueFilePath, GalleryMapperObject galleryMapperObject)
        {
            var uploadedFile = new Gallery()
            {
                ProjectId = galleryMapperObject.ProjectId,
                ArticleId = galleryMapperObject.ArticleId,
                FileName = uniqueFilePath
            };


            this.personalBlogDbContext
                .Gallery
                .Add(uploadedFile);

            await this.personalBlogDbContext.SaveChangesAsync();
        }

        public bool ValidateMultupleFiles(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (ImageValidator.CheckIfFileIsBigger(file) ||
                    ImageValidator.CheckIfFileIsForbidden(file))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task UploadImageInFileStorage(IFormFile file, string filePath)
        {
            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
        }

        public async Task UploadImage(IFormFile file, GalleryMapperObject galleryMapperObject)
        {
            var fileUniqueName = ReturnUniqueFileName() + getFileExtension(file);
            var filePath = ReturnFullFilePath(this.webHostEnvironment.WebRootPath, fileUniqueName);

            await this.UploadImageInDB(file, fileUniqueName, galleryMapperObject);
            await this.UploadImageInFileStorage(file, filePath);

        }

        public void DeleteImageFromFileStorage(IEnumerable<Gallery> files)
        {
            foreach (var file in files)
            {
                var filePath = ReturnFullFilePath(this.webHostEnvironment.WebRootPath, file.FileName);
                File.Delete(filePath);
            }

        }

        public async Task DeleteImageFromDB(IEnumerable<Gallery> files)
        {
            foreach (var file in files)
            {
                this.personalBlogDbContext.Remove(file);
            }

            await this.personalBlogDbContext.SaveChangesAsync();

        }

    }
}
