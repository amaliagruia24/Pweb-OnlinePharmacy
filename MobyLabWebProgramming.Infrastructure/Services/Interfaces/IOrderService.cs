using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ServiceResponse<OrderDTO>> GetOrder(Guid id, CancellationToken cancellationToken = default);
        public Task<ServiceResponse<OrderDTO>> GetOrders(CancellationToken cancellationToken = default);

        public Task<ServiceResponse> AddOrder(OrderDTO order, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> UpdateOrder(OrderDTO order, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);

        public Task<ServiceResponse> DeleteOrder(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    }
}
