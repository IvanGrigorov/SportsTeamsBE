namespace PersonalBlog.Features.Articles.Models
{
    using PersonalBlog.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PlayerDetailsResponseModel
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
        public string TeamName { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
