namespace Web.ViewModels.Borrows
{
    public class BorrowVM
    {
        public string BookTitle { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public string picUrl { get; set; }
        public bool IsReturned { get; set; }
        public string Slug { get; set; }

    }
}
