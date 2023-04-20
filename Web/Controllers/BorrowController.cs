using Core.Entites;
using Core.Entites.Hold;
using Core.Interfaces;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Areas.Admin.Factories;
using Web.ViewModels.Account;
namespace Web.Controllers
{
    public class BorrowController:Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHoldModelFactory holdModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BorrowController(UserManager<ApplicationUser> userManager, IHoldModelFactory holdModelFactory, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.holdModelFactory = holdModelFactory;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("MyBorrows")]
        public async Task<ActionResult> MyBorrows()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByEmailAsync(email);
            var model = await holdModelFactory.PrepareBorrowClientAsync(user);
            return View(model);
        }

    }
}
