namespace PersonalBlog.Features.Discovery
{
    using PersonalBlog.Features.Discovery.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDiscoveryService
    {
        public Task<IEnumerable<DiscoveryResponseModel>> Discover(DiscoveryRequestModel discoveryRequestModel);
    }
}
