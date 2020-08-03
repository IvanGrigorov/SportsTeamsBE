namespace PersonalBlog.Features.Technologies
{
    using System.ComponentModel.DataAnnotations;
    using static Infrastructure.Constants.Validation.Technology;


    public class TechnologyRequestModel
    {
        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }

    }
}
