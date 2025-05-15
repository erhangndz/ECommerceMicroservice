using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderings = await _mediator.Send(new GetOrderingQuery());
            return Ok(orderings);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order Created");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            if (value is null)
            {
                return BadRequest("Ordering Not Found");
            }

            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Order Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Order Deleted");
        }
    }
}
