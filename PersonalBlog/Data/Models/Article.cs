namespace PersonalBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Article;


    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BodyValidationLength)]
        public string Body { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        [MaxLength(TagsValidationLength)]
        public string TagsJson { get; set; }

        public List<Gallery> Gallery { get; set; }

    }
}
