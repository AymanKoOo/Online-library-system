using AyyBlog.ViewModel;
using Core.Entites.Books;
using Core.Entites.Borrowing;
using Core.Entites.Media;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repo.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class BookRepo : GenericRepo<Book>, IBookRepo
    {
        private readonly DataContext _dbcontext;
        public BookRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }


        public string MakeBookSlugUnique(string Slug)
        {
            int i = 0;
            while (_dbcontext.books.Any(x => x.Slug == Slug))
            {
                Slug = $"{Slug}-{i++}";
            }
            return Slug;
        }

        public async Task<Book> GetBookBySlug(string slug)
        {
            return await _dbcontext.books.Include(x => x.BookPictures).ThenInclude(x => x.Picture)
               .FirstOrDefaultAsync(x => x.Slug == slug);
        }


        public async Task<Book> GetBookByID(int id) => await _dbcontext.books.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddBookPicture(int bookId, int picID)
        {
            var model = new BookPicture
            {
                BookID = bookId,
                PictureId = picID,
                DisplayOrder = 1
            };
            await _dbcontext.bookPictures.AddAsync(model);
        }
        public async Task DeleteBookPictures(int bookId)
        {
            var pics = _dbcontext.bookPictures.Where(x => x.BookID == bookId).ToList();
            foreach (var p in pics)
            {
                var pic = _dbcontext.pictures.Where(x => x.Id == p.PictureId).First();
                _dbcontext.bookPictures.Remove(p);
                _dbcontext.pictures.Remove(pic);
            }
            await _dbcontext.SaveChangesAsync();
        }
        public IQueryable<BookPicture> GetBookPictureByBookID(int id)
        {
            return _dbcontext.bookPictures.Where(x => x.BookID == id)
                  .Include(x => x.Picture);
        }
        public async Task<string> GetBookPictureURLByBookID(int id){
           
            var pictureMimeType = await _dbcontext.bookPictures
            .Where(x => x.BookID == id)
            .Include(x=>x.Picture)
            .Select(x => x.Picture.MimeType)
            .FirstOrDefaultAsync();

            return pictureMimeType;
        }

        public async Task<List<Picture>> GetBookPicturesAsync(int bookId)
        {
            var pictures = await _dbcontext.bookPictures
                .Where(bp => bp.BookID == bookId)
                .Select(bp => bp.Picture)
                .ToListAsync();

            return pictures;
        }
        public void UpdateBookPicture(BookPicture bookPic)
        {
            _dbcontext.bookPictures.Update(bookPic);
        }

        public async Task<BookPicture> GetBookPictureByPicID(int picId)
        {
            return await _dbcontext.bookPictures.Where(x => x.PictureId == picId).FirstOrDefaultAsync();
        }
        public async Task<BookPicture> GetBookPictureByBookId(int bookId)
        {
            return await _dbcontext.bookPictures.Where(x => x.BookID == bookId).Include(x => x.Picture).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Book>> GetAllBooktList(int pageSize, int pageNumber)
        {
            var books = _dbcontext.books.Include(p=>p.BookPictures).ThenInclude(x=>x.Picture);

            return await PagedList<Book>.ToPagedList(books,
            pageNumber,
            pageSize);
        }

   

    }
}
