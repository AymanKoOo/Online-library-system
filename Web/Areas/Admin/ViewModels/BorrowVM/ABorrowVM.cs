using Core.Entites;
using Web.ViewModels.Home;

namespace Web.Areas.Admin.ViewModels.BorrowVM
{
    public class ABorrowVM
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public BookVM Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
