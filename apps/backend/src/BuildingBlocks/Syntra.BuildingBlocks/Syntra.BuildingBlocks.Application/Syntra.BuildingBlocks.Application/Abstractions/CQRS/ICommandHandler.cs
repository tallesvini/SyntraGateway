using MediatR;

namespace Syntra.BuildingBlocks.Application.Abstractions.CQRS
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse> { }
}
