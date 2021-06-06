namespace PersonalBlog.Features.Bases
{
    using PersonalBlog.Data;

    public abstract class BaseApiService
    {
        protected readonly SportsAppDbContext sportsAppDbContext;
        public BaseApiService(SportsAppDbContext sportsAppDbContext)
        {
            this.sportsAppDbContext = sportsAppDbContext;
        }
    }
}
