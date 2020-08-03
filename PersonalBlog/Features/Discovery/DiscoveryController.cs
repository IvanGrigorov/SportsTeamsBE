namespace PersonalBlog.Features.Discovery
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Discovery.Models;
    using PersonalBlog.Features.Navigation;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class DiscoveryController : HobbiesAppController
    {
        private readonly IDiscoveryService discoveryService;

        public DiscoveryController(IDiscoveryService discoveryService)
        {
            this.discoveryService = discoveryService;
        }

        [HttpPost]
        [Route(nameof(Discover))]
        public async Task<IEnumerable<DiscoveryResponseModel>> Discover(DiscoveryRequestModel discoveryRequestModel)
        {
            return await this.discoveryService.Discover(discoveryRequestModel);
        }
    }
}
