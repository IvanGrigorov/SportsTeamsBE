namespace PersonalBlog.Features.Articles.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleRequestModel
    {
        [Required]
        public string Body { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string TagsJson { get; set; }

        public IEnumerable<IFormFile> Gallery { get; set; } = new List<IFormFile>();
    }
}
