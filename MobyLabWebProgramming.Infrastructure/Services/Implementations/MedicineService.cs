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
    public class MedicineService : IMedicineService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public MedicineService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse> AddMedicine(MedicineAddDTO medicine, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can add medicine!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new MedicineSpec(medicine.MedicineName), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(System.Net.HttpStatusCode.Conflict, "The med already exists!"));
            }

            await _repository.AddAsync(new Medicine
            {
                MedicineName = medicine.MedicineName,
                MedicinePrice = medicine.MedicinePrice,
                MedicineDescription = medicine.MedicineDescription,
                MedicineMeasurement = medicine.MedicineMeasurement,
                Quantity = medicine.Quantity,
                ExpiryDate = medicine.ExpiryDate,
                Image = medicine.Image,
                MedicineTypeId = medicine.MedicineTypeId,
                MedicineCategoryId = medicine.MedicineCategoryId,
                SupplierId = medicine.SupplierId,
            }, cancellationToken);

            return ServiceResponse.ForSuccess();

        }

        public async Task<ServiceResponse> DeleteMedicine(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can delete medicine!", ErrorCodes.CannotDelete));
            }

            await _repository.DeleteAsync<Medicine>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse<MedicineDTO>> GetMedicine(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new MedicineSpec(id), cancellationToken);
            MedicineDTO returnedMedicine = null;
            if (result != null)
            {
                returnedMedicine = new MedicineDTO
                {
                    MedicineName = result.MedicineName,
                    MedicineDescription = result.MedicineDescription,
                    MedicineType = result.MedicineType,
                    MedicineCategory = result.MedicineCategory,
                    MedicineMeasurement = result.MedicineMeasurement,
                    MedicinePrice = result.MedicinePrice,
                    Quantity = result.Quantity,
                    ExpiryDate = result.ExpiryDate,
                    Image = result.Image,
                    Supplier = result.Supplier,
                };
            }

            return result != null ?
                ServiceResponse<MedicineDTO>.ForSuccess(returnedMedicine) :
                ServiceResponse<MedicineDTO>.FromError(new(System.Net.HttpStatusCode.Conflict, "The medicine doesn't exist"));
        }

        public Task<ServiceResponse<MedicineDTO>> GetMedicines(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> UpdateMedicine(MedicineDTO medicine, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can update medicine!", ErrorCodes.CannotUpdate));
            }
            var entity = await _repository.GetAsync(new MedicineSpec(medicine.Id), cancellationToken);

            if (entity != null)
            {
                Medicine medicineToUpdate = new Medicine
                {
                    Id = entity.Id,
                    MedicineName = entity.MedicineName,
                    MedicineCategoryId = entity.MedicineCategory.Id,
                    MedicineTypeId = entity.MedicineType.Id,
                    SupplierId = entity.Supplier.Id,
                    MedicinePrice = entity.MedicinePrice,
                    MedicineDescription = entity.MedicineDescription,
                    MedicineMeasurement = entity.MedicineMeasurement,
                    ExpiryDate = entity.ExpiryDate,
                    Quantity = entity.Quantity,
                };

                await _repository.UpdateAsync(medicineToUpdate, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
