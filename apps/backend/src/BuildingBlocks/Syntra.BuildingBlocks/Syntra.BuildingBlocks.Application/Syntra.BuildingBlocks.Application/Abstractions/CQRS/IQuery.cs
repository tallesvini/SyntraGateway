using MediatR;

namespace Syntra.BuildingBlocks.Application.Abstractions.CQRS
{
    public interface IQuery<out TResponse>
        : IRequest<TResponse> { }
}
