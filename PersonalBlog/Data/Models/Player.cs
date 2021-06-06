
namespace SportsApp.Data.Models
{
    using PersonalBlog.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Player;
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameLength)]

        public string FirstName { get; set; }

        [Required]
        [MaxLength(SecondNameLength)]

        public string SecondName { get; set; }

        [Required]
        public Team Team { get; set; }


        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string TeamId { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

    }
}
