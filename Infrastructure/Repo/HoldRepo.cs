using AyyBlog.ViewModel;
using Core.Entites.Books;
using Core.Entites.Hold;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repo.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class HoldRepo : GenericRepo<Hold>, IHoldRepo
    {
        private readonly DataContext _dbcontext;
        public HoldRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Hold>> GetAllHolds()
        {
            return await _dbcontext.holds
              .ToListAsync();
        }

        public async Task<Hold> GetHoldByID(int id)
        {
            return await _dbcontext.holds.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<PagedList<Hold>> GetAllHoldsList(int pageSize, int pageNumber)
        {
            var holdModel = _dbcontext.holds.Include(x=>x.User).Include(p => p.Book);

            return await PagedList<Hold>.ToPagedList(holdModel,
            pageNumber,
            pageSize);
        }
        public async Task<IEnumerable<Hold>> GetAllHoldsByUser(string userId)
        {
            return await _dbcontext.holds.Where(x => x.UserId == userId).Include(x => x.Book)
                .ToListAsync();
        }
        public async Task UserHoldBook(string userID,Book book)
        {
            // Decrement AvailableQuantity
            if (book.AvailableQuantity > 0)
            {
                book.AvailableQuantity--;
                _dbcontext.books.Update(book);
                await _dbcontext.SaveChangesAsync();
                DateTime now = DateTime.Now;
                var holdModel = new Hold
                {
                    UserId = userID,
                    BookId = book.Id,
                    HoldPlaced = now
                };
                await _dbcontext.holds.AddAsync(holdModel);
            }
        }
        public async Task<bool> CheckUserNOHoldSameBook(string userID, Book book)
        {
            var holdflag = await _dbcontext.holds.Where(x => x.UserId == userID && x.BookId == book.Id).AnyAsync();
            return holdflag;
        }

        public async Task UserCancelHoldBook(string userID, Book book)
        {
           var hold = await _dbcontext.holds.Where(x => x.UserId == userID && x.BookId == book.Id).FirstOrDefaultAsync();
           _dbcontext.holds.Remove(hold);

           book.AvailableQuantity++;
           _dbcontext.books.Update(book);
        }
    }
}
