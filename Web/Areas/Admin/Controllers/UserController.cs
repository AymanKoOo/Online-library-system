using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
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
            _unitOfWork.Save();
            return RedirectToAction("Index", "User");
        }
    }
}
