using System.Runtime.InteropServices;
using System.Text.Json;
using ECommerce.Basket.DTOs;

namespace ECommerce.Basket.Services.BasketServices
{
    public class BasketService(RedisService _redisService) : IBasketService
    {
        public async Task<bool> DeleteAsync(string userId)
        {
           return await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketDto> GetBasketAsync(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            return JsonSerializer.Deserialize<BasketDto>(existBasket);
        }

        public async Task SaveOrUpdateAsync(BasketDto basketDto)
        {
            var basket = JsonSerializer.Serialize(basketDto);
            await _redisService.GetDb().StringSetAsync(basketDto.UserId, basket);
        }
    }
}
