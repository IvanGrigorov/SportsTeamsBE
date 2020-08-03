namespace PersonalBlog.Features.Articles.Models
{

    using System.ComponentModel.DataAnnotations;

    public class ArticleUpdateRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TagsJson { get; set; }
    }
}
