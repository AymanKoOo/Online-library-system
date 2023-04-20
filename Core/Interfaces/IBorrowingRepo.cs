using AyyBlog.ViewModel;
using Core.Entites.Books;
using Core.Entites.Borrowing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBorrowingRepo : IGenericRepo<Borrowing>
    {
        public Task borrowHolder(int holdID, int borrowDueDays);
        public Task<PagedList<Borrowing>> GetAllBorrowList(int pageSize, int pageNumber);
        public Task<Borrowing> getBorrowbyID(int borrowID);
        public Task<IEnumerable<Borrowing>> GetAllBorrowsByUser(string userId);

    }
}
