namespace PersonalBlog.Features.Articles.Models
{

    using System.ComponentModel.DataAnnotations;

    public class TeamUpdateRequestModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
