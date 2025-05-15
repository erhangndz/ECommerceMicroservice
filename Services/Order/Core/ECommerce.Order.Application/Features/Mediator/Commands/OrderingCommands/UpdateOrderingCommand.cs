using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
