using AyyBlog.ViewModel;
using Core.Entites.Borrowing;
using Core.Entites.Hold;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly DataContext _dbcontext;
        public BorrowingRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public async Task<Borrowing> getBorrowbyID(int borrowID)
        {
           return await _dbcontext.borrowings.Where(x => x.Id == borrowID).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Borrowing>> GetAllBorrowsByUser(string userId)
        {
            return await _dbcontext.borrowings.Where(x => x.UserId == userId).Include(x => x.Book)
                .ToListAsync();
        }
        public async Task borrowHolder(int holdID,int borrowDueDays)
        {
           var hold = await _dbcontext.holds.Where(x => x.Id == holdID).Include(x=>x.User).Include(x=>x.Book).FirstOrDefaultAsync();
           DateTime now = DateTime.Now;

            var borrow = new Borrowing
            {
                UserId = hold.UserId,
                BookId = hold.BookId,
                BorrowedDate = now,
                DueDate = now.AddDays(borrowDueDays),
                ReturnedDate = null,
                IsReturned = false
            };
            await _dbcontext.borrowings.AddAsync(borrow);
            _dbcontext.holds.Remove(hold);
        }

        public async Task<PagedList<Borrowing>> GetAllBorrowList(int pageSize, int pageNumber)
        {
            var borrowModel = _dbcontext.borrowings.Include(x => x.User).Include(p => p.Book);
            return await PagedList<Borrowing>.ToPagedList(borrowModel,
            pageNumber,
            pageSize);
        }
    }
}
