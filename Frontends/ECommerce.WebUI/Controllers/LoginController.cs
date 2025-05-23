using ECommerce.WebUI.DTOs.IdentityDtos;
using ECommerce.WebUI.Services.IdentityServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECommerce.WebUI.Controllers
{
    public class LoginController(IIdentityService _identityService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto model)
        {
            var result = await _identityService.SignInAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "UserName or Password incorrect");
                return View(model);
            }

            return RedirectToAction("Index", "Category");


        }

        public async Task<IActionResult> Logout()
        {
            await _identityService.SignoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
