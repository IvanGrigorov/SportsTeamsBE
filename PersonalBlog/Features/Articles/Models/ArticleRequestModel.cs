namespace PersonalBlog.Features.Articles.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Infrastructure.Constants.Validation.Article;


    public class ArticleRequestModel
    {
        [Required]
        [MaxLength(BodyValidationLength)]
        public string Body { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string TagsJson { get; set; }

        public IEnumerable<IFormFile> Gallery { get; set; } = new List<IFormFile>();
    }
}
