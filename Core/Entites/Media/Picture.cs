using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using Core.Entites.Books;

namespace Core.Entites.Media
{
    public class Picture : EntityBase
    {
        public string MimeType { get; set; }
        public List<BookPicture> BookPictures { get; set; }
    }
}
