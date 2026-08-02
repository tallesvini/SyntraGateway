using MediatR;

namespace Syntra.BuildingBlocks.Application.Abstractions.CQRS
{
    public interface ICommand<out TResponse>
        : IRequest<TResponse> { }

    public interface ICommand
        : IRequest { }
}
