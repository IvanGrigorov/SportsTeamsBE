using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Features.Bases;
using PersonalBlog.Features.Discovery.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Features.Discovery
{
    public class DiscoveryService : BaseApiService, IDiscoveryService
    {
        public DiscoveryService(PersonalBlogDbContext personalBlogDbContext) :base(personalBlogDbContext)
        {

        }

        public async Task<IEnumerable<DiscoveryResponseModel>> Discover(DiscoveryRequestModel discoveryRequestModel)
        {
            return await this.personalBlogDbContext
                            .Article
                            .Where(a => a.Title.Contains(discoveryRequestModel.Query) ||
                                        a.TagsJson.Contains(discoveryRequestModel.Query))
                            .Select(a => new DiscoveryResponseModel
                            {
                                Id = a.Id,
                                Title = a.Title
                            })
                            .ToListAsync();
        }
    }
}
