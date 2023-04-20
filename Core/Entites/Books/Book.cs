using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites.Books
{
    public class Book:EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ISBN { get; set; }
        public string Genre { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }

        public List<BookPicture> BookPictures { get; set; }
    }
}
