using Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class PictureService : IPictureService
    {
        private readonly IUnitOfWork unitOfWork;

        public PictureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> UploadPictureAsync(IFormFile formFile, string WebRootPath = "", string defaultFileName = "", string virtualPath = "")
        {
            var imgExt = new List<string>
            {
                ".bmp",
                ".gif",
                ".webp",
                ".jpeg",
                ".jpg",
                ".jpe",
                ".jfif",
                ".pjpeg",
                ".pjp",
                ".png",
                ".tiff",
                ".tif"
            } as IReadOnlyCollection<string>;
             
            
            //added image to upload folder//
            var fileName = formFile.FileName;
            if (string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(defaultFileName))
                fileName = defaultFileName;
            string fullPath = "";
            if (!string.IsNullOrEmpty(formFile.Name))
            {
                string uploads = Path.Combine(WebRootPath, "uploads");
                fileName = Guid.NewGuid() + Path.GetExtension(formFile.FileName).ToLower();
                fullPath = Path.Combine(uploads, fileName);
                await formFile.CopyToAsync(new FileStream(fullPath, FileMode.Create));
            }

            return fileName;
        }
    }
}
