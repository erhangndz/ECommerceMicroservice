using System.Security.Cryptography;
using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services.BasketServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService _basketService) : ControllerBase
    {

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket(string userId)
        {
            var values = await _basketService.GetBasketAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketDto basketDto)
        {
            await _basketService.SaveOrUpdateAsync(basketDto);
            return Ok("Basket Changes Saved");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var result =  await _basketService.DeleteAsync(userId);

            return result ? Ok("Basket Deleted") : BadRequest("Basket Delete Failed");

        }
    }
}
