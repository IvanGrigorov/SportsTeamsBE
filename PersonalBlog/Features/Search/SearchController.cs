namespace PersonalBlog.Features.Search
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SearchController : BaseAppController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<SearchResponseModel> Search(SearchRequestModel searchRequestModel)
        {
            return await this.searchService.GetSearchedItems(searchRequestModel);
        }
    }
}
