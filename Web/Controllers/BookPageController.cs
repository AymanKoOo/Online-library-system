using Core.Interfaces;
using Infrastructure.Repo.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Areas.Admin.Factories;

namespace Web.Controllers
{
    public class BookPageController: Controller
    {
        private readonly IBookModelFactory bookModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BookPageController(IBookModelFactory bookModelFactory, IUnitOfWork unitOfWork)
        {
            this.bookModelFactory = bookModelFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var bookModel = await bookModelFactory.PrepareBookModelClientAsync(slug);
            return View(bookModel);
        }
    }
}
