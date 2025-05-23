using ECommerce.WebUI.DTOs.IdentityDtos;

namespace ECommerce.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync(SignInDto signInDto);

        Task SignoutAsync();
        Task<bool> GetRefreshToken();
    }
}
