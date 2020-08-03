namespace PersonalBlog.Features.Technologies
{
    using System.ComponentModel.DataAnnotations;

    public class TechnologyRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
