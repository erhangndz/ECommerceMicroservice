using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;

public record GetOrderingByIdQuery(int Id) : IRequest<GetOrderingByIdQueryResult>;


