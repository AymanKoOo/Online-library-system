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
    [Authorize]
    public class HoldController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHoldModelFactory holdModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public HoldController(UserManager<ApplicationUser> userManager,IHoldModelFactory holdModelFactory, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.holdModelFactory = holdModelFactory;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("MyHolds")]
        public async Task<ActionResult> MyHolds()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByEmailAsync(email);
            var model = await holdModelFactory.PrepareMyHoldsModelClientAsync(user);
            return View(model);
        }

        [HttpGet]
        [Route("HoldBook")]
        public async Task<IActionResult> HoldBook(string slug)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByEmailAsync(email);
            
            if (string.IsNullOrEmpty(user.Id))
            {
                return Unauthorized();
            }

            var book = await _unitOfWork.book.GetBookBySlug(slug);
            if (book == null)
            {
                return NotFound();
            }
            if (book.AvailableQuantity <= 0)
            {
                return NotFound();
            }

            var flag = await _unitOfWork.hold.CheckUserNOHoldSameBook(user.Id, book);
            if (flag == true)
            {
                return NotFound();
            }
           
            await _unitOfWork.hold.UserHoldBook(user.Id, book);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("MyHolds", "Hold");
        }


        [HttpGet]
        [Route("CancelHold")]
        public async Task<IActionResult> CancelHold(string slug)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized();
            }

            var user = await userManager.FindByEmailAsync(email);

            if (string.IsNullOrEmpty(user.Id))
            {
                return Unauthorized();
            }

            var book = await _unitOfWork.book.GetBookBySlug(slug);
            if (book == null)
            {
                return NotFound();
            }
            if (book.AvailableQuantity <= 0)
            {
                return NotFound();
            }

            await _unitOfWork.hold.UserCancelHoldBook(user.Id, book);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("MyHolds", "Hold");
        }

    }
}
