namespace PersonalBlog.Features.Search
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Navigation;
    using PersonalBlog.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SearchController : ProgrammingAppController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        [Route(nameof(Search))]
        public async Task<IEnumerable<ProjectSearchResponseModel>> Search(ProjectSearchRequestModel projectSearchRequestModel)
        {
            return await this.searchService.GetSearchedProjects(projectSearchRequestModel);
        }
    }
}
