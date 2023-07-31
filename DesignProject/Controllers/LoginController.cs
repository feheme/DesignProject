using DesignProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
            if (!ModelState.IsValid)
            {

                return View(loginUserDto);
            }

            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();


        }
        public async Task<IActionResult> Logout()
        {
            // Oturumu kapat
            await _signInManager.SignOutAsync();

            // İstenilen yönlendirme yapılabilir
            return RedirectToAction("Index", "Login");
        }
    }
}
