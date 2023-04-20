using Core.Entites.Borrowing;
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
    }
}
