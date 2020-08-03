namespace PersonalBlog.Features.Technologies.Model
{
    using System.ComponentModel.DataAnnotations;
    using static Infrastructure.Constants.Validation.Technology;

    public class TechnologyUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }
    }
}
