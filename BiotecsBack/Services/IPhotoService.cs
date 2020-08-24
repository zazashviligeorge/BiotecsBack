using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiotecsBack.Services
{
    public interface IPhotoService
    {

        public void ResizeImage(IFormFile uploadedFile, string desiredThumbPath, int desiredWidth = 0,
            int desiredHeight = 0);
        void DeleteFile(string fileName, string currentDirectory);
        Task<string> UploadPhoto(IFormFile image, string currentDirectory);
    }
}
