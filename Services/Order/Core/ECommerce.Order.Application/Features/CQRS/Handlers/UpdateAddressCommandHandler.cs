using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class UpdateAddressCommandHandler(IRepository<Address> _repository)
    {

        public async Task Handle(UpdateAddressCommand command)
        {
            var address = command.Adapt<Address>();
            await _repository.UpdateAsync(address);
        }

    }
}
