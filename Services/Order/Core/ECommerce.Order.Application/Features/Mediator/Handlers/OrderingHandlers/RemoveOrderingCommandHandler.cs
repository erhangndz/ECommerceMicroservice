using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class RemoveOrderingCommandHandler(IRepository<Ordering> _repository) : IRequestHandler<RemoveOrderingCommand>
{
    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
    }
}