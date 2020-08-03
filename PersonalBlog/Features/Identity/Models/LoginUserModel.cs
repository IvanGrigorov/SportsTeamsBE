namespace PersonalBlog.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
