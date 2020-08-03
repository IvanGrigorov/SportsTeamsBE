namespace PersonalBlog.Features.Articles.Models
{

    using System.ComponentModel.DataAnnotations;
    using static Infrastructure.Constants.Validation.Article;

    public class ArticleUpdateRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BodyValidationLength)]
        public string Body { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public string TagsJson { get; set; }
    }
}
