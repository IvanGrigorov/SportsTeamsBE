namespace SportsApp.Data.Models
{
    using PersonalBlog.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static PersonalBlog.Infrastructure.Constants.Validation.Team;

    public class Team
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TeamNameLength)]
        public string Name { get; set; }

        [Required]
        public IEnumerable<Player> Players { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
