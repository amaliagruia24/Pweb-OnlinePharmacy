using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IMedicineTypeService
    {
        public Task<ServiceResponse<MedicineTypeDTO>> GetMedicineType(Guid id, CancellationToken cancellationToken = default);

        public Task<ServiceResponse<MedicineTypeDTO>> GetMedicineTypes(CancellationToken cancellationToken = default);

        public Task<ServiceResponse> AddMedicineType(MedicineTypeAddDTO medicineType, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> UpdateMedicineType(MedicineTypeDTO medicineType, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> DeleteMedicineType(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    }
}
