using AutoMapper;
using Core.Entites;
using Core.Entites.Books;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Web.Areas.Admin.ViewModels.Book;
using Web.Services;
using Web.ViewModels.BookPage;
using Web.ViewModels.Home;
using System.Web;
using Microsoft.AspNetCore.Http;
using Web.ViewModels.Holds;
using Core.Entites.Hold;

namespace Web.Areas.Admin.Factories
{
    public class BookModelFactory:IBookModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ABookList> PrepareBookListModelAsync(int pageSize, int pageNumber)
        {
            var books = await unitOfWork.book.GetAllBooktList(pageSize, pageNumber);

            //using deletate to retrieve data instead of passing data directly to the PreareToGrid function 
            //Overall, using a delegate to retrieve the data is a design pattern that promotes loose coupling and makes the code more flexible and reusable.
            var model = new ABookList().PrepareToGrid(books, () =>
            {
                //fill in model values from the entity
                return books.Data.Select(book =>
                {
                    var bookModel = mapper.Map<ABookVM>(book);
                    return bookModel;
                });
            });
            return model;
        }
        public async Task<BookListVM> PrepareBookListModelClientAsync(int pageSize, int pageNumber)
        {
            var books = await unitOfWork.book.GetAllBooktList(pageSize, pageNumber);
            //using deletate to retrieve data instead of passing data directly to the PreareToGrid function 
            //Overall, using a delegate to retrieve the data is a design pattern that promotes loose coupling and makes the code more flexible and reusable.
            var model = new BookListVM().PrepareToGrid(books, () =>
            {
                //fill in model values from the entity
                return books.Data.Select(book =>
                {
                    var NewbookModel = mapper.Map<BookVM>(book);
                    NewbookModel.PicturePath = book.BookPictures.First().Picture.MimeType;
                    return NewbookModel;
                });
            });
            return model;
        }

        public async Task<BookPageVM> PrepareBookModelClientAsync(string bookSlug,ApplicationUser user)
        {
            var book = await unitOfWork.book.GetBookBySlug(bookSlug);

            var model = mapper.Map<Book, BookPageVM>(book);

            if (user != null)
            {
                var holds = await unitOfWork.hold.GetAllHoldsByUser(user.Id);
                var holdsUser = mapper.Map<IEnumerable<Hold>, IEnumerable<HoldVM>>(holds);
                model.Userholds = holdsUser;
            }
            
            model.PicturePath = book.BookPictures.First().Picture.MimeType;
            return model;
        }
    }
    
}
