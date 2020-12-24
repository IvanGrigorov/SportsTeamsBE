namespace PersonalBlog.Features.Articles
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Articles.Models;
    using PersonalBlog.Features.Galleries;
    using PersonalBlog.Features.Galleries.Models;
    using PersonalBlog.Features.Navigation;
    using PersonalBlog.Infrastructure.Extensions;
    using PersonalBlog.Infrastructure.Filters;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.Constants.AppConstants.RoutesContants;
    using static Infrastructure.Constants.Validation.Request; 
     
    public class ArticleController : HobbiesAppController
    {
        private readonly IArticleService articleService;
        private readonly IGalleryService galleryService;


        public ArticleController(IArticleService articleService, IGalleryService galleryService)
        {
            this.articleService = articleService;
            this.galleryService = galleryService;
        }

        [HttpPost]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Create))]
        [RequestSizeLimit(RequestBodySize)]

        public async Task<int> Create([FromForm] ArticleRequestModel articleRequestModel)
        {
            var userId = this.User.GetId();
            var articleId = await this.articleService.CreateArticle(articleRequestModel, userId);
            var galleryObjectMapper = new GalleryMapperObject
            {
                ArticleId = articleId
            };
            await this.galleryService.ObtainMultipleFiles(articleRequestModel.Gallery, galleryObjectMapper);
            return articleId;
        }

        [HttpPut]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromForm] ArticleUpdateRequestModel articleUpdateRequestModel)
        {
            var userId = this.User.GetId();
            var isUpdateSuccessful = await this.articleService.UpdateArticle(articleUpdateRequestModel, userId);
            if (isUpdateSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize]
        [IsAdmin]
        [Route(DeleteByID)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.GetId();

            var galleryMappedObject = new GalleryMapperObject
            {
                ArticleId = id
            };

            var files = await this.galleryService.ReturnFilesForDeletion(galleryMappedObject);

            var isDeletionSuccessful = await this.articleService.DeleteArticle(id, userId);

            if (!isDeletionSuccessful)
            {
                return BadRequest();
            }

            // await this.galleryService.DeleteImageFromDB(files);
            this.galleryService.DeleteImageFromFileStorage(files);

            return Ok();
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<ArticleCollectionResponseModel>> All()
        {
            return await this.articleService.GetAllArticles();
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ArticleDetailsResponseModel> Get(int id)
        {
            return await this.articleService.Get(id);
        }
    }
}
