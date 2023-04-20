using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class BorrowingController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IHoldModelFactory holdModelFactory;
        private readonly IWebHostEnvironment environment;
        private readonly IPictureService picture;
        private readonly IBookModelFactory bookModelFactory;
        private readonly ISlugService _slugService;
        private readonly IMapper _mapper;

        public BorrowingController(IUnitOfWork unitOfWork,IHoldModelFactory holdModelFactory, IPictureService picture, IBookModelFactory bookModelFactory, IMapper mapper, ISlugService slugService, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this.holdModelFactory = holdModelFactory;
            this.picture = picture;
            this.bookModelFactory = bookModelFactory;
            this.environment = environment;
            _slugService = slugService;
        }
        public async Task<IActionResult> Index(int pageSize = 5, int pageNumber = 1)
        {
            //var holds = holdModelFactory.
            var model = await holdModelFactory.PrepareHoldListModelAsync(pageSize, pageNumber);

            return View(model);
        }


        [HttpGet("ShowBorrow")]
        public async Task<IActionResult> ShowBorrow(int pageSize = 5, int pageNumber = 1)
        {
            var model = await holdModelFactory.PrepareBorrowListModelAsync(pageSize, pageNumber);
            return View(model);
        }

        [HttpGet("Borrow")]
        public async Task<IActionResult> Borrow(int holdId)
        {
            await _unitOfWork.borrowing.borrowHolder(holdId, 7);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("ShowBorrow", "Borrowing");
        }

        [HttpGet("Returned")]
        public async Task<IActionResult> Returned(int borrowId)
        {
            DateTime now = DateTime.Now;
            var borrow = await _unitOfWork.borrowing.getBorrowbyID(borrowId);
            if(borrow == null)
            {
                return NotFound();
            }
            if(borrow.IsReturned == true)
            {
                return NotFound();
            }
            borrow.IsReturned = true;
            borrow.ReturnedDate = now;
            _unitOfWork.borrowing.Update(borrow);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("ShowBorrow", "Borrowing");
        }
    }
}
