namespace PersonalBlog.Features.Bases
{
    using PersonalBlog.Data;

    public abstract class BaseApiService
    {
        protected readonly PersonalBlogDbContext personalBlogDbContext;
        public BaseApiService(PersonalBlogDbContext personalBlogDbContext)
        {
            this.personalBlogDbContext = personalBlogDbContext;
        }
    }
}
