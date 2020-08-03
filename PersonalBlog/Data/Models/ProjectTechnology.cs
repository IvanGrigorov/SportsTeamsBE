namespace PersonalBlog.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectTechnology
    {

        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public int TechnologyId { get; set; }

        public Technology Technology { get; set; }
    }
}
