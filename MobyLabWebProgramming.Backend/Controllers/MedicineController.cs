using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MedicineController : AuthorizedController
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IUserService userService, IMedicineService medicineService) : base(userService)
        {
            _medicineService = medicineService;
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RequestResponse<MedicineDTO>>> GetById([FromRoute] Guid id)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineService.GetMedicine(id)) :
                this.ErrorMessageResult<MedicineDTO>(currentUser.Error);

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RequestResponse<PagedResponse<MedicineDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination) // The FromQuery attribute will bind the parameters matching the names of
                                                                                                                                             // the PaginationSearchQueryParams properties to the object in the method parameter.
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineService.GetMedicines(pagination)) :
                this.ErrorMessageResult<PagedResponse<MedicineDTO>>(currentUser.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<RequestResponse>> Add([FromBody] MedicineAddDTO medicine)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineService.AddMedicine(medicine, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<RequestResponse>> Update([FromBody] MedicineDTO medicine)
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineService.UpdateMedicine(medicine, currentUser.Result)) :
                this.ErrorMessageResult(currentUser.Error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
        {
            var currentUser = await GetCurrentUser();

            return currentUser.Result != null ?
                this.FromServiceResponse(await _medicineService.DeleteMedicine(id)) :
                this.ErrorMessageResult(currentUser.Error);
        }

    }
}
