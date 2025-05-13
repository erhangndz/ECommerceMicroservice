using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Features.CQRS.Handlers;
using ECommerce.Order.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(GetAddressQueryHandler _getAddressQueryHandler, 
                                     GetAddressByIdQueryHandler _getAddressByIdQueryHandler,
                                     CreateAddressCommandHandler _createAddressCommandHandler,
                                     UpdateAddressCommandHandler _updateAddressCommandHandler,
                                     RemoveAddressCommandHandler _removeAddressCommandHandler) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _getAddressQueryHandler.Handle();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Address Created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Address Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address Deleted");
        }


    }
}
