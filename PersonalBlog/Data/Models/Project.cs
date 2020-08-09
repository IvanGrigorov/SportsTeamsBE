namespace PersonalBlog.Data.Models
{
    using static PersonalBlog.Infrastructure.Constants.Validation.Project;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }

        public List<Gallery> Gallery { get; set; }

        [Required]
        public string Website { get; set; }
    }
}
