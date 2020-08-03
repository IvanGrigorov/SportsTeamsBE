namespace PersonalBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15000)]
        public string Body { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string TagsJson { get; set; }

        public List<Gallery> Gallery { get; set; }

    }
}
