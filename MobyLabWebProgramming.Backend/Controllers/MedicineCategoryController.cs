using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MedicineCategoryController : AuthorizedController
    {
        private readonly IMedicineCategoryService _medicineCategoryService;

        public MedicineCategoryController(IUserService userService, IMedicineCategoryService medicineCategoryService) : base(userService)
        {
            _medicineCategoryService = medicineCategoryService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] MedicineCategoryAddDTO medicineCategoryAddDTO)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineCategoryService.AddMedicineCategory(medicineCategoryAddDTO, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<MedicineCategoryDTO>>> GetById([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
               this.FromServiceResponse(await _medicineCategoryService.GetMedicineCategory(id)) :
               this.ErrorMessageResult<MedicineCategoryDTO>(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineCategoryService.DeleteMedicineCategory(id)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] MedicineCategoryDTO categoryDTO)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineCategoryService.UpdateMedicineCategory(categoryDTO, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }
    }
}
