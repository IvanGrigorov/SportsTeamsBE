namespace PersonalBlog.Features.Articles
{
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles.Models;
    using PersonalBlog.Features.Bases;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ArticleService : BaseApiService, IArticleService
    {

        public ArticleService(PersonalBlogDbContext personalBlogDbContext) :base(personalBlogDbContext)
        {
        }

        public async Task<int> CreateArticle(ArticleRequestModel articleRequestModel, string userId)
        {
            var article = new Article
            {
                Title = articleRequestModel.Title,
                Body = articleRequestModel.Body,
                CreatedOn = articleRequestModel.CreatedOn,
                TagsJson = articleRequestModel.TagsJson,
                UserId = userId
            };

            this.personalBlogDbContext
                .Article
                .Add(article);

            await this.personalBlogDbContext.SaveChangesAsync();
            return article.Id;
        }

        public async Task<bool> DeleteArticle(int id, string userId)
        {
            var article = await this.GetArticleByIdAndUserId(id, userId);
            if (article == null)
            {
                return false;
            }
            this.personalBlogDbContext.Remove(article);
            await this.personalBlogDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ArticleDetailsResponseModel> Get(int id)
        {
            return await this.personalBlogDbContext
                        .Article
                        .Where(a => a.Id == id)
                        .Select(a => new ArticleDetailsResponseModel
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Body = a.Body,
                            CreatedOn = a.CreatedOn,
                            Tags = a.TagsJson,
                            Gallery = a.Gallery
                        })
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ArticleCollectionResponseModel>> GetAllArticles()
        {
            return await this.personalBlogDbContext
                    .Article
                    .Select(a => new ArticleCollectionResponseModel
                    {
                        Id = a.Id,
                        Title = a.Title
                    })
                    .ToListAsync();
        }

        public async Task<bool> UpdateArticle(ArticleUpdateRequestModel articleUpdateRequestModel, string userId)
        {
            var article = await this.GetArticleByIdAndUserId(articleUpdateRequestModel.Id, userId);
            if (article == null)
            {
                return false;
            }
            article.Title = articleUpdateRequestModel.Title;
            article.Body = articleUpdateRequestModel.Body;
            article.TagsJson = articleUpdateRequestModel.TagsJson;

            await this.personalBlogDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Article> GetArticleByIdAndUserId(int articleId, string userId)
        {
            return await this.personalBlogDbContext
                .Article
                .Where(a => a.Id == articleId && a.UserId == userId)
                .FirstOrDefaultAsync();
            
        }
    }
}
