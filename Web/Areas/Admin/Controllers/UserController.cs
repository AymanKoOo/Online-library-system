using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class UserController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = _unitOfWork.Admin.GetAllUsersWithRole();
            return View(users);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(string UserID)
        {
            var user = await _unitOfWork.Admin.GetUserByID(UserID);
            _unitOfWork.Admin.DeleteUser(user);
            await _userManager.DeleteAsync(user);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _unitOfWork.Save();
            return RedirectToAction("Login", "Account");
        }
    }
}
