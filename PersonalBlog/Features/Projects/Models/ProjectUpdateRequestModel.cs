namespace PersonalBlog.Features.Projects
{
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Project;

    public class ProjectUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public int[] Technologies { get; set; }
    }
}
