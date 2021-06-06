namespace PersonalBlog.Features.Articles.Models
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public class TeamRequestModel
    {
        [Required]
        public string TeamName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }
}
