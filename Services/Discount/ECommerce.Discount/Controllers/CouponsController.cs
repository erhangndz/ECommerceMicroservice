using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext _context) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _context.Coupons.ToListAsync();

            var values = coupons.Select(x => new ResultCouponDto
            {
                CouponId = x.CouponId,
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                ExpireDate = x.ExpireDate,
                ProductId = x.ProductId
            }).ToList();

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto couponDto)
        {
            var coupon = new Coupon
            {
                Code = couponDto.Code,
                DiscountRate = couponDto.DiscountRate,
                ExpireDate = couponDto.ExpireDate,
                ProductId = couponDto.ProductId
            };
            await _context.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return Ok("Kupon başarıyla oluşturuldu");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Kupon Bulunamadı");
            }
            var value = new ResultCouponDto
            {
                DiscountRate = coupon.DiscountRate,
                ExpireDate = coupon.ExpireDate,
                Code = coupon.Code,
                CouponId = coupon.CouponId,
                ProductId = coupon.ProductId
            };

            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto couponDto)
        {
            var coupon = new Coupon
            {
                CouponId = couponDto.CouponId,
                ExpireDate = couponDto.ExpireDate,
                Code = couponDto.Code,
                DiscountRate = couponDto.DiscountRate,
                ProductId = couponDto.ProductId
            };

            _context.Update(coupon);
            await _context.SaveChangesAsync();
            return Ok("Kupon başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Silinecek Kupon Bulunamadı");
            }

            _context.Remove(coupon);
            await _context.SaveChangesAsync();
            return Ok("Kupon başarıyla silindi");
        }
    }
}
