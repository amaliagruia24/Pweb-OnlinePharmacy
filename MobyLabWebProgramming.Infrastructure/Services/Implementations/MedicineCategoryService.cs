using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class MedicineCategoryService : IMedicineCategoryService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;
        public MedicineCategoryService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse> AddMedicineCategory(MedicineCategoryAddDTO medCategory, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new MedicineCategorySpec(medCategory.CategoryName), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(System.Net.HttpStatusCode.Conflict, "The med category already exists!"));
            }

            await _repository.AddAsync(new MedicineCategory
            {
                CategoryName = medCategory.CategoryName,
            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteMedicineCategory(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync<MedicineCategory>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }

        public Task<ServiceResponse<MedicineCategoryDTO>> GetMedicineCategories(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<MedicineCategoryDTO>> GetMedicineCategory(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new MedicineCategorySpec(id), cancellationToken);

            MedicineCategoryDTO returnedCategory = new MedicineCategoryDTO
            {
                CategoryName = result.CategoryName,
            };

            return result != null ?
                ServiceResponse<MedicineCategoryDTO>.ForSuccess(returnedCategory) :
                ServiceResponse<MedicineCategoryDTO>.FromError(new(System.Net.HttpStatusCode.Conflict, "The category doesn't exist"));
        }

        public async Task<ServiceResponse> UpdateMedicineCategory(MedicineCategoryDTO medCategory, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(new MedicineCategorySpec(medCategory.Id), cancellationToken);

            if (entity != null)
            {
                entity.CategoryName = medCategory.CategoryName ?? entity.CategoryName;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
