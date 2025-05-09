using ECommerce.Order.Application.Features.CQRS.Queries;
using ECommerce.Order.Application.Features.CQRS.Results;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class GetAddressByIdQueryHandler(IRepository<Address> _repository)
    {


        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            if (value is null)
            {
                throw new Exception("Adres Bilgisi Bulunamadı");
            }

            return value.Adapt<GetAddressByIdQueryResult>();
        }

    }
}
