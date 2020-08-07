namespace PersonalBlog.Features.Articles
{
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        public Task<int> CreateArticle(ArticleRequestModel articleRequestModel, string userId);

        public Task<bool> DeleteArticle(int id, string userId);

        public Task<bool> UpdateArticle(ArticleUpdateRequestModel articleUpdateRequestModel, string userId);

        public Task<IEnumerable<ArticleCollectionResponseModel>> GetAllArticles();

        public Task<ArticleDetailsResponseModel> Get(int id);

        public Task<Article> GetArticleByIdAndUserId(int articleId, string userId);



    }
}
