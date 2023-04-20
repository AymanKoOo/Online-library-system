using Web.Areas.Admin.ViewModels.Book;
using Web.ViewModels.BookPage;
using Web.ViewModels.Home;

namespace Web.Areas.Admin.Factories
{
    public interface IBookModelFactory
    {
        Task<ABookList> PrepareBookListModelAsync(int pageSize, int pageNumber);
        Task<BookListVM> PrepareBookListModelClientAsync(int pageSize, int pageNumber);
        Task<BookPageVM> PrepareBookModelClientAsync(string bookSlug);
    }
}
