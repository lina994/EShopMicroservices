namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler
    : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
