namespace PersonalBlog.Features.Technologies
{
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Technologies.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITechologyService
    {
        public Task<int> CreateTechnology(TechnologyRequestModel technologyRequestModel);

        public Task<IEnumerable<TechnologyResponseModel>> GetAllTechnologies();

        public Task<bool> DeleteTechnology(int technologyId);

        public Task<bool> UpdateTechnology(TechnologyUpdateRequestModel technologyUpdateRequestModel);

        public Task<Technology> GetTechnologyById(int technologyId);

    }
}
