using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Features.Discovery.Models
{
    public class DiscoveryRequestModel
    {
        [Required]
        public string Query { get; set; }
    }
}
