using Core.Entites.Books;
using Core.Entites;
using Web.Areas.Admin.ViewModels.Book;
using Web.ViewModels.Home;

namespace Web.ViewModels.Holds
{
    public class HoldVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string BookTitle { get; set; }
        public DateTime HoldPlaced { get; set; }
        public string BookPicUrl { get; set; }
        public string BookSlug { get; set; }


    }
}
