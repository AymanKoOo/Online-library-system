using AyyBlog.ViewModel;
using Core.Entites.Books;
using Core.Entites.Media;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookRepo:IGenericRepo<Book>
    {
        public Task<string> GetBookPictureURLByBookID(int id);
        public string MakeBookSlugUnique(string Slug);
        public Task<Book> GetBookBySlug(string slug);
        public Task AddBookPicture(int bookId, int picID);
        public Task<Book> GetBookByID(int id);
        public Task DeleteBookPictures(int bookId);
        public IQueryable<BookPicture> GetBookPictureByBookID(int id);
        public void UpdateBookPicture(BookPicture bookPic);
        public Task<BookPicture> GetBookPictureByPicID(int picId);
        public Task<PagedList<Book>> GetAllBooktList(int pageSize, int pageNumber);
     
        public Task<List<Picture>> GetBookPicturesAsync(int bookId);
    }
}
