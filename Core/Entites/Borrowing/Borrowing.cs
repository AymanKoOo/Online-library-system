using Core.Entites.Base;
using Core.Entites.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites.Borrowing
{
    public class Borrowing:EntityBase
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
