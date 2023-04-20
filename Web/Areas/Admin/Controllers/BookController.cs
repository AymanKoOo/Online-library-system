using AutoMapper;
using Core.Entites.Books;
using Core.Entites.Media;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Book;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class BookController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment environment;
        private readonly IPictureService picture;
        private readonly IBookModelFactory bookModelFactory;
        private readonly ISlugService _slugService;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork, IPictureService picture, IBookModelFactory bookModelFactory, IMapper mapper, ISlugService slugService, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this.picture = picture;
            this.bookModelFactory = bookModelFactory;
            this.environment = environment;
            _slugService = slugService;
        }

        public async Task<IActionResult> Index(int pageSize = 1, int pageNumber = 1)
        {
            var booklist = await bookModelFactory.PrepareBookListModelAsync(pageSize, pageNumber);
            return View(booklist);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ABookVM model)
        {
            if (!ModelState.IsValid || model.PictureFile == null)
            {
                ModelState.AddModelError(string.Empty, "Add Book Picture");
                return View(model);
            }

            var picName = await picture.UploadPictureAsync(model.PictureFile, environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };

            await _unitOfWork.picture.Add(picObj);

            var bookModel = _mapper.Map<Book>(model);

            string bookSlug = _slugService.createSlug(model.Title);

            string uniqueSlug = _unitOfWork.book.MakeBookSlugUnique(bookSlug);

            bookModel.Slug = uniqueSlug;

            await _unitOfWork.book.Add(bookModel);

            _unitOfWork.Save();

            var pic = await _unitOfWork.picture.getPicByName(picName);

            var book = await _unitOfWork.book.GetBookBySlug(uniqueSlug);

            await _unitOfWork.book.AddBookPicture(book.Id, pic.Id);

            _unitOfWork.Save();
            return RedirectToAction("Index", "Book");
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int bookID)
        {
            var book = await _unitOfWork.book.GetBookByID(bookID);

            _unitOfWork.book.Delete(book);

            _unitOfWork.Save();
            return RedirectToAction("Index", "Book");
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int bookID)
        {
            var book = await _unitOfWork.book.GetBookByID(bookID);
            var vmbook = _mapper.Map<Book, ABookVM>(book);
            return View(vmbook);
        }

            [HttpPost("Edit")]
            public async Task<IActionResult> Edit(ABookVM model)
            {
                var bookPics = await _unitOfWork.book.GetBookPicturesAsync(model.Id);
                
                if (bookPics == null)
                {
                    ModelState.AddModelError(string.Empty, "Add Book Picture");
                    return View(model);
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await UpdatePicture(model);

                string bookSlug = _slugService.createSlug(model.Title);

                string uniqueSlug = _unitOfWork.book.MakeBookSlugUnique(bookSlug);

                var finalModel = _mapper.Map<ABookVM, Book>(model);

                finalModel.Slug = uniqueSlug;

                _unitOfWork.book.Update(finalModel);
                await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "Book");
            }
            
            private async Task UpdatePicture(ABookVM model)
            {
                // Add new picture
                if (model.PictureFile != null)
                {
                    await _unitOfWork.book.DeleteBookPictures(model.Id);

                    var picName = await picture.UploadPictureAsync(model.PictureFile, environment.WebRootPath);
 
                    var picObj = new Picture
                    {
                        MimeType = picName,
                    };
                    
                    await _unitOfWork.picture.Add(picObj);
                    await _unitOfWork.SaveAsync();

                    var pic = await _unitOfWork.picture.getPicByName(picName);

                    await _unitOfWork.book.AddBookPicture(model.Id, pic.Id);
                }
            }

    }
}

