using Core.Entites;

namespace Web.Areas.Admin.ViewModels.HoldVM
{
    public class AHoldVM
    {
        public int HoldID { get; set; }
        public string Email { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
