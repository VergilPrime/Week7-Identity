using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCMultiverse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCMultiverse.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: /<controller>/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View();
        }

        // GET: /<controller>/Register/
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string secret)
        {
            if (secret == "IAmAnAbsolutelySafeAndSecureHardCodedPassword")
            {
                ApplicationUser user = await _userManager.GetUserAsync(User);
                await _userManager.AddToRoleAsync(user, "Admin");
                return StatusCode(200);
            }

            return StatusCode(403);
        }
    }
}
