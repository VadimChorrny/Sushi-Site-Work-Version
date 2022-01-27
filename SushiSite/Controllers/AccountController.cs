using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SushiSite.Models;

namespace SushiSite.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        public IActionResult Index()
        {
            return View();
        }
    }
}
