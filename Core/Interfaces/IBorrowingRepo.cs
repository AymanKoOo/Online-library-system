using Core.Entites.Books;
using Core.Entites.Borrowing;
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
    }
}
