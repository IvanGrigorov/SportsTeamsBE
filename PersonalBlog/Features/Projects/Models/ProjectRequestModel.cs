namespace PersonalBlog.Features.Projects
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Project;
    public class ProjectRequestModel
    {
        [Required]
        [MaxLength(DescriptionValidationLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(TitleValidationLength)]
        public string Title { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public int[] Technologies { get; set; }

        public IEnumerable<IFormFile> Gallery { get; set; } = new List<IFormFile>();
    }
}
