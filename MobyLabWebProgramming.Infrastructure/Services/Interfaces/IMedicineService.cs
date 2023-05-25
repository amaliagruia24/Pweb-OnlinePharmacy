using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IMedicineService
    {
        public Task<ServiceResponse<MedicineDTO>> GetMedicine(Guid id, CancellationToken cancellationToken = default);

        public Task<ServiceResponse<PagedResponse<MedicineDTO>>> GetMedicines(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> AddMedicine(MedicineAddDTO medicine, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> UpdateMedicine(MedicineDTO medicine, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> DeleteMedicine(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

    }
}
