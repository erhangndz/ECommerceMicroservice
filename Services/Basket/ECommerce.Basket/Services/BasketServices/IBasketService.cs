using ECommerce.Basket.DTOs;

namespace ECommerce.Basket.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string userId);

        Task SaveOrUpdateAsync(BasketDto basketDto);

        Task<bool> DeleteAsync(string userId);

    }
}
