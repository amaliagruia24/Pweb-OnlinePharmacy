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
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;

        public SupplierService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> AddSupplier(SupplierAddDTO supplier, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add suppliers!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new SupplierSpec(supplier.SupplierName), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(System.Net.HttpStatusCode.Conflict, "The supplier already exists!"));
            }

            await _repository.AddAsync(new Supplier
            {
                SupplierName = supplier.SupplierName

            }, cancellationToken);

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse> DeleteSupplier(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only personnel can delete suppliers!", ErrorCodes.CannotDelete));
            }

            await _repository.DeleteAsync<Supplier>(id, cancellationToken);
            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse<SupplierDTO>> GetSupplier(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetAsync(new SupplierSpec(id), cancellationToken);

            SupplierDTO returnedSupplier = new SupplierDTO
            {
                SupplierName = result.SupplierName,
            };

            return result != null ?
                ServiceResponse<SupplierDTO>.ForSuccess(returnedSupplier) :
                ServiceResponse<SupplierDTO>.FromError(new(System.Net.HttpStatusCode.Conflict, "The supplier doesn't exist"));
        }

        public Task<ServiceResponse<SupplierDTO>> GetSuppliers(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> UpdateSupplier(SupplierDTO supplier, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the personnel can update users!", ErrorCodes.CannotUpdate));
            }

            var entity = await _repository.GetAsync(new SupplierSpec(supplier.Id), cancellationToken);

            if (entity != null)
            {
                entity.SupplierName = supplier.SupplierName ?? entity.SupplierName;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
