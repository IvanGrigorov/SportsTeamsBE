namespace PersonalBlog.Features.Technologies
{

    using System.ComponentModel.DataAnnotations;

    public class TechnologyResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
