using ECommerce.Message.DTOs;

namespace ECommerce.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllAsync();
        Task<ResultUserMessageDto> GetByIdAsync(int id);
        Task CreateAsync(CreateUserMessageDto messageDto);
        Task UpdateAsync(int id,UpdateUserMessageDto messageDto);
        Task DeleteAsync(int id);

    }
}
