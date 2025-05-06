using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.CategoryServices;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            await categoryService.CreateAsync(category);
            return Ok(category);
        }

    }
}
