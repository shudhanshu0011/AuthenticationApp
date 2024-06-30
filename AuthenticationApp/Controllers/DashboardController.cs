using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Dotnet6MvcLogin.Models.Domain;
using System.Threading.Tasks;

namespace Dotnet6MvcLogin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Display()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.FirstName = user.FirstName;
                ViewBag.LastName = user.LastName;
            }

            return View();
        }
    }
}
