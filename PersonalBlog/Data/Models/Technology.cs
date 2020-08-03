namespace PersonalBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Technology
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
