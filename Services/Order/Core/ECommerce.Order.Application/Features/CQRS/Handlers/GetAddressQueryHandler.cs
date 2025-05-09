using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressQueryHandler(IRepository<Address> _repository)
    {

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Adapt<List<GetAddressQueryResult>>();
        }


    }
}
