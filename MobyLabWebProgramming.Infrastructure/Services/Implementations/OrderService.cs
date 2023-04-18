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
    public class OrderService : IOrderService
    {
        private readonly IRepository<WebAppDatabaseContext> _repository;
        public OrderService(IRepository<WebAppDatabaseContext> repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> AddOrder(OrderDTO order, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Id != order.UserId) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only own users can place orders!", ErrorCodes.CannotAdd));
            }

            var result = await _repository.GetAsync(new OrderSpec(order.Id), cancellationToken);

            if (result != null)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The order already exists!"));
            }

            await _repository.AddAsync(new Order
            {
                UserId = order.UserId,
                OrderAmount = order.OrderAmount
            }, cancellationToken);

            return ServiceResponse.ForSuccess();

        }

        public async Task<ServiceResponse> DeleteOrder(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel && requestingUser.Id != id) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the personnel or the own user can delete the order!", ErrorCodes.CannotDelete));
            }

            await _repository.DeleteAsync<Order>(id, cancellationToken); // Delete the entity.

            return ServiceResponse.ForSuccess();
        }

        public async Task<ServiceResponse<OrderDTO>> GetOrder(Guid id, CancellationToken cancellationToken = default)
        {

            var result = await _repository.GetAsync(new OrderSpec(id), cancellationToken); // Get a user using a specification on the repository.

            OrderDTO returnedOrder = new OrderDTO
            {
                UserId = result.UserId,
                OrderAmount = result.OrderAmount,
            };
            return result != null ?
                ServiceResponse<OrderDTO>.ForSuccess(returnedOrder) :
                ServiceResponse<OrderDTO>.FromError(CommonErrors.UserNotFound);
        }

        public Task<ServiceResponse<OrderDTO>> GetOrders(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> UpdateOrder(OrderDTO order, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
        {
            if (requestingUser != null && requestingUser.Role != UserRoleEnum.Personnel && requestingUser.Id != order.UserId) // Verify who can add the user, you can change this however you se fit.
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the personnel or the own user can update the order!", ErrorCodes.CannotUpdate));
            }

            var entity = await _repository.GetAsync(new OrderSpec(order.Id), cancellationToken);

            if (entity != null)
            {
                entity.UserId = order.UserId;
                entity.OrderAmount = order.OrderAmount;

                await _repository.UpdateAsync(entity, cancellationToken);
            }

            return ServiceResponse.ForSuccess();
        }
    }
}
