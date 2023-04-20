using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Areas.Admin.Factories;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookModelFactory bookModelFactory;

        public HomeController(ILogger<HomeController> logger, IBookModelFactory bookModelFactory)
        {
            _logger = logger;
            this.bookModelFactory = bookModelFactory;
        }

        public async Task<IActionResult> Index(int pageSize = 6, int pageNumber = 1)
        {
            var booklist = await bookModelFactory.PrepareBookListModelClientAsync(pageSize, pageNumber);
            return View(booklist);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}