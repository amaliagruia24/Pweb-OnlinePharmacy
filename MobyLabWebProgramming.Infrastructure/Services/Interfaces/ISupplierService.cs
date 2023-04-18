using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface ISupplierService
    {
        public Task<ServiceResponse<SupplierDTO>> GetSupplier(Guid id, CancellationToken cancellationToken = default);

        public Task<ServiceResponse<SupplierDTO>> GetSuppliers(CancellationToken cancellationToken = default);

        public Task<ServiceResponse> AddSupplier(SupplierAddDTO supplier, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> UpdateSupplier(SupplierAddDTO supplier, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> DeleteSupplier(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    }
}
