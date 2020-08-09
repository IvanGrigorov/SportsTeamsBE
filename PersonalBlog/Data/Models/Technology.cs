namespace PersonalBlog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Technology;


    public class Technology
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
