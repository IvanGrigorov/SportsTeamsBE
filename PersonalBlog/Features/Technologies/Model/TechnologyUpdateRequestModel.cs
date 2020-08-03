namespace PersonalBlog.Features.Technologies.Model
{
    using System.ComponentModel.DataAnnotations;

    public class TechnologyUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
