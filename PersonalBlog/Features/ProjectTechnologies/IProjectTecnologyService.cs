namespace PersonalBlog.Features.ProjectTechnologies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProjectTecnologyService
    {
        public Task AddProjectTechnologyMapping(int projectId, int[] technologyIds);

        public Task<bool> UpdateProjectTechnologies(int projectId, int[] technologyIds);

        public void AddAllTechnologies(int projectId, int[] technologyIds);

    }
}
