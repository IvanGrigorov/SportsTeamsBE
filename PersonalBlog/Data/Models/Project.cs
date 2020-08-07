using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalBlog.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        [Required]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }

        public List<Gallery> Gallery { get; set; }

        [Required]
        public string Website { get; set; }
    }
}
