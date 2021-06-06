namespace PersonalBlog.Features.Articles.Models
{
    using PersonalBlog.Data.Models;
    using SportsApp.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamDetailsResponseModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
