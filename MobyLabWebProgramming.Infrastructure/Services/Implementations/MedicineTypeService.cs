using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations
{
    public class MedicineTypeService : IMedicineTypeService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public MedicineTypeService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse> AddMedicineType(MedicineTypeAddDTO medicineType, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can add medicine types!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new MedicineTypeSpec(medicineType.TypeName), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(System.Net.HttpStatusCode.Conflict, "The med type already exists!"));
            }

            await _repository.AddAsync(new MedicineType
            {
                TypeName = medicineType.TypeName,
            }, cancellationToken);

            return ServiceResponse.ForSuccess();

        }

        public async Task<ServiceResponse> DeleteMedicineType(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can delete medicine types!", ErrorCodes.CannotDelete));
            }
            await _repository.DeleteAsync<MedicineType>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse<MedicineTypeDTO>> GetMedicineType(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new MedicineTypeSpec(id), cancellationToken);

            MedicineTypeDTO returnedType = new MedicineTypeDTO
            {
                TypeName = result.TypeName
            };

            return result != null ?
                ServiceResponse<MedicineTypeDTO>.ForSuccess(returnedType) :
                ServiceResponse<MedicineTypeDTO>.FromError(new(System.Net.HttpStatusCode.Conflict, "The med type doesn't exist"));
        }

        public async Task<ServiceResponse<MedicineTypeDTO>> GetMedicineTypes(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> UpdateMedicineType(MedicineTypeDTO medicineType, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can update medicine types!", ErrorCodes.CannotUpdate));
            }

            var entity = await _repository.GetAsync(new MedicineTypeSpec(medicineType.Id), cancellationToken);

            if (entity == null)
            {
                return ServiceResponse.FromError(new (HttpStatusCode.NotFound, "MedicineType Not found"));
            }

            if (entity != null)
            {
                entity.TypeName = medicineType.TypeName ?? entity.TypeName;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
