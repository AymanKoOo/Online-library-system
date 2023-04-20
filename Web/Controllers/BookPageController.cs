using Core.Entites;
using Core.Interfaces;
using Infrastructure.Repo.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Web.Areas.Admin.Factories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web.Controllers
{
    public class BookPageController: Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBookModelFactory bookModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BookPageController(UserManager<ApplicationUser> userManager, IBookModelFactory bookModelFactory, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.bookModelFactory = bookModelFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = email != null ? await userManager.FindByEmailAsync(email) : null;
            var bookModel = await bookModelFactory.PrepareBookModelClientAsync(slug, user);

            return View(bookModel);
        }

    }
}
