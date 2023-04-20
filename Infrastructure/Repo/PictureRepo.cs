using Core.Entites.Media;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class PictureRepo : GenericRepo<Picture>, IPictureRepo
    {
        private readonly DataContext _dbcontext;
        public PictureRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public Task<Picture> getPicByName(string name)
        {
            return _dbcontext.pictures.FirstOrDefaultAsync(x => x.MimeType == name);
        }
        public Task<Picture> getPicById(int id)
        {
            return _dbcontext.pictures.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
