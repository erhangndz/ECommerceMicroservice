using MediatR;
using System.Text.Json.Serialization;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand : IRequest
    {
        public string UserId { get; set; }

        [JsonIgnore]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
