namespace PersonalBlog.Features.Navigation
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Bases;

    [ApiController]
    [Route("Programming/[controller]")]
    public abstract class ProgrammingAppController : BaseAppController
    {
    }
}
