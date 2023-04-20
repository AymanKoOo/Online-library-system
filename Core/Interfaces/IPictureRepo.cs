using Core.Entites.Books;
using Core.Entites.Media;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPictureRepo : IGenericRepo<Picture>
    {
        public Task<Picture> getPicByName(string name);


        public Task<Picture> getPicById(int id);
     
    }
}
