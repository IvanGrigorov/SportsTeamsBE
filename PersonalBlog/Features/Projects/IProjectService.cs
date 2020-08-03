namespace PersonalBlog.Features.Projects
{
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Projects.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProjectService
    {
        public Task<int> CreateProject(ProjectRequestModel projectRequestModel, string userId);

        public Task<ProjecDetailsServiceModel> GetProject(int id);

        public Task<IEnumerable<ProjectCollectionServiceModel>> GetByUser(string userId);

        public Task<IEnumerable<ProjectCollectionServiceModel>> GetAllProjects();

        public Task<bool> DeleteProject(int projectId, string userId);

        public Task<bool> UpdateProject(ProjectUpdateRequestModel projectUpdateRequestModel, string userId);

        public Task<Project> GetProjectByIdAndUserId(int projectId, string userId);


    }
}
