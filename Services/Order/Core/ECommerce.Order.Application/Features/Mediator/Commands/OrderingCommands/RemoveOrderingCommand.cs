using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;

public record RemoveOrderingCommand(int Id) : IRequest;
