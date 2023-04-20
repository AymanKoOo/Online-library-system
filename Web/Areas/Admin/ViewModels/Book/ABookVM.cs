using Core.Entites.Books;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Admin.ViewModels.Book
{
    public class ABookVM:BaseEntityModel
    {
        [Required]
        [StringLength(200, ErrorMessage = "Max length is 20 Charcter", MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Max length is 10 Charcter", MinimumLength = 4)]
        public string Author { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Max length is 10 Charcter", MinimumLength = 4)]
        public string Publisher { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Max length is 10 Charcter", MinimumLength = 4)]
        public string Genre { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Max length is 20 Charcter", MinimumLength = 4)]
        public string Description { get; set; }

        [Required]
        public bool InStock { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        public IFormFile PictureFile { get; set; }
        public int MainpictureID { get; set; }
    }
}
