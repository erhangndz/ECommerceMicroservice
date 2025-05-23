using System.Net.Http.Headers;
using ECommerce.WebUI.DTOs.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Http.Headers;

namespace ECommerce.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService(HttpClient _client) : ICategoryService
    {
  
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            await _client.PostAsJsonAsync("categories", categoryDto);
        }

        public async Task DeleteAsync(string id)
        {
            await _client.DeleteAsync("categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<ResultCategoryDto> GetByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<ResultCategoryDto>("categories/" + id);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            await _client.PutAsJsonAsync("categories", categoryDto);
        }
    }
}
