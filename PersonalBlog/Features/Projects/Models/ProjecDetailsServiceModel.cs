namespace PersonalBlog.Features.Projects.Models
{
    using PersonalBlog.Data.Models;
    using System.Collections.Generic;

    public class ProjecDetailsServiceModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string CreatedOn { get; set; }

        public string Website { get; set; }

        public IEnumerable<Technology> Technologies { get; set; }

        public IEnumerable<Gallery> Gallery { get; set; }

    }
}
