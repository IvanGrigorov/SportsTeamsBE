
namespace PersonalBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class Gallery
    {
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string FileName { get; set; }

        public Project Project { get; set; }

        public Article Article { get; set; }

    }
}
