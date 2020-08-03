namespace PersonalBlog.Features.Navigation
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Bases;

    [ApiController]
    [Route("Hobbies/[controller]")]
    public abstract class HobbiesAppController : BaseAppController
    {
    }
}
