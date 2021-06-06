namespace PersonalBlog.Features.Articles.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class PlayerRequestModel
    {
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
