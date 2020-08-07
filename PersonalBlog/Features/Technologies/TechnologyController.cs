namespace PersonalBlog.Features.Technologies
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Navigation;
    using PersonalBlog.Features.Technologies.Model;
    using PersonalBlog.Infrastructure.Filters;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.Constants.AppConstants.RoutesContants;

    public class TechnologyController : ProgrammingAppController
    {

        private readonly ITechologyService techologyService;

        public TechnologyController(ITechologyService techologyService)
        {
            this.techologyService = techologyService;
        }

        [Authorize]
        [IsAdmin]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(TechnologyRequestModel technologyRequestModel)
        {

            var technologyId = await this.techologyService.CreateTechnology(technologyRequestModel);

            return Created(nameof(Create), technologyId);

        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IEnumerable<TechnologyResponseModel>> GetAll()
        {
            var technologies = await this.techologyService.GetAllTechnologies();

            return technologies;

        }

        [HttpGet]
        [Route(Id)]
        public async Task<TechnologyResponseModel> Technology(int id)
        {
            var technology = await this.techologyService.GetTechnology(id);

            return technology;

        }

        [Authorize]
        [IsAdmin]
        [HttpDelete]
        [Route(DeleteByID)]
        public async Task<IActionResult> Delete(int id)
        {

            var isDeletionSuccessful = await this.techologyService.DeleteTechnology(id);

            if (!isDeletionSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [IsAdmin]
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update(TechnologyUpdateRequestModel technologyUpdateRequestModel)
        {

            var isTechnologyUpdateSuccessful = await this.techologyService.UpdateTechnology(technologyUpdateRequestModel);
            if (!isTechnologyUpdateSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
