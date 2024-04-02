using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
    }

    // The out keyword before TResponse indicates that TResponse is covariant,
    // meaning that you can use a more derived type as the type argument when
    // implementing the interface.
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
