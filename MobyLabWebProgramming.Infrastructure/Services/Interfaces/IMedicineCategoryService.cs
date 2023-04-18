using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IMedicineCategoryService
    {
        public Task<ServiceResponse<MedicineCategoryDTO>> GetMedicineCategory(Guid id, CancellationToken cancellationToken = default);

        public Task<ServiceResponse<MedicineCategoryDTO>> GetMedicineCategories(CancellationToken cancellationToken = default);

        public Task<ServiceResponse> AddMedicineCategory(MedicineCategoryAddDTO medCategory, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> UpdateMedicineCategory(MedicineCategoryDTO medCategory, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> DeleteMedicineCategory(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    }
}
