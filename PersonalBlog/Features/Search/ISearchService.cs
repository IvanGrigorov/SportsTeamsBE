﻿namespace PersonalBlog.Features.Search
{
    using PersonalBlog.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ISearchService
    {
        public Task<IEnumerable<ProjectSearchResponseModel>> GetSearchedProjects(ProjectSearchRequestModel projectSearchRequestModel);
    }
}
