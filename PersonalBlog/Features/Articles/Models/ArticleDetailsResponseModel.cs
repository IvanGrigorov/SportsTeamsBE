namespace PersonalBlog.Features.Articles.Models
{
    using PersonalBlog.Data.Models;
    using System.Collections.Generic;

    public class ArticleDetailsResponseModel
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

        public string CreatedOn { get; set; }

        public string UserName { get; set; }

        public string Tags { get; set; }

        public IEnumerable<Gallery> Gallery { get; set; }
    }
}
