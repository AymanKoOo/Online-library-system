using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.Media;

namespace Core.Entites.Books
{
    public class BookPicture
    {
        public int BookID { get; set; }
        public Book Book { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int DisplayOrder { get; set; }
    }
}
