using FluentValidation;
using Ordering.Data;
using Ordering.Orders.Exceptions;
using Shared.Contracts.CQRS;

namespace Ordering.Orders.Features.DeleteOrder
{
    public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderReuslt>;
    public record DeleteOrderReuslt(bool IsSuccess);
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
        }
    }

    internal class DeleteOrderHandler(OrderingDbContext dbContext) : ICommandHandler<DeleteOrderCommand, DeleteOrderReuslt>
    {
        public async Task<DeleteOrderReuslt> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await dbContext.Orders.FindAsync([command.OrderId], cancellationToken: cancellationToken);
            if (order == null)
            {
                throw new OrderNotFoundException(command.OrderId);
            }

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteOrderReuslt(true);
        }
    }
}
