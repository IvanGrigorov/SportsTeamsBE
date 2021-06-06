namespace PersonalBlog.Features.Articles.Models
{

    using System.ComponentModel.DataAnnotations;

    public class PlayerUpdateRequestModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string TeamId { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
