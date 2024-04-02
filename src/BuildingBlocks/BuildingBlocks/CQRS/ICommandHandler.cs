using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand>
        : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {
    }

    // The in keyword before TCommand indicates that TCommand is contravariant,
    // meaning that you can use a less derived type as the type argument when
    // implementing the interface.
    public interface ICommandHandler<in TCommand, TResponse>
        : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
