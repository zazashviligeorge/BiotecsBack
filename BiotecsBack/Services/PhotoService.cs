using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BiotecsBack.Services.FileHandling;
using Microsoft.AspNetCore.Http;
using LazZiya.ImageResize;
using Microsoft.EntityFrameworkCore.Internal;

namespace BiotecsBack.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IFileHandler _fileHandler;

        public PhotoService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public void DeleteFile(string fileName, string currentDirectory)
        {
            var folderPath = _fileHandler.GetAbsolutePath(currentDirectory);
            var fileFullPaths = _fileHandler.EnumerateFiles(folderPath,"*",false);
            foreach (var fullPath in fileFullPaths)
            {
                if (_fileHandler.GetFileName(fullPath)== fileName)
                {
                    _fileHandler.DeleteFile(fullPath);
                }
            }
            
        }

        public async Task<string> UploadPhoto(IFormFile image, string currentDirectory)
        {
            if (image == null || image.Length == 0)
                throw new NullReferenceException("no file chosen.");

            var folderPath = _fileHandler.GetAbsolutePath(currentDirectory);
            _fileHandler.CreateDirectory(folderPath);

            var randomFileName = _fileHandler.GetRandomFileName(image.FileName);

            var photoPath = _fileHandler.Combine(folderPath, randomFileName);

            using (var stream = new FileStream(photoPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return randomFileName;
        }

        public void ResizeImage(IFormFile uploadedFile, string desiredThumbPath, int desiredWidth = 0, int desiredHeight = 0)
        {
            string webRoot = _fileHandler.GetRootUrl();

            if (uploadedFile.Length > 0)
            {
                using (var stream = uploadedFile.OpenReadStream())
                {
                    var uploadedImage = System.Drawing.Image.FromStream(stream);

                    //decide how to scale dimensions
                    if (desiredHeight == 0 && desiredWidth > 0)
                    {
                        var img = uploadedImage.ScaleByWidth(desiredWidth); // returns System.Drawing.Image file
                        var fullPath = Path.Combine(webRoot, desiredThumbPath);
                        var currentFolder = _fileHandler.GetDirectoryName(fullPath);
                        _fileHandler.CreateDirectory(currentFolder);
                        img.SaveAs(fullPath);
                    }
                    else if (desiredWidth == 0 && desiredHeight > 0)
                    {
                        var img = uploadedImage.ScaleByHeight(desiredHeight); // returns System.Drawing.Image file
                        var fullPath = Path.Combine(webRoot, desiredThumbPath);
                        var currentFolder = _fileHandler.GetDirectoryName(fullPath);
                        _fileHandler.CreateDirectory(currentFolder);
                        img.SaveAs(fullPath);
                    }
                    else
                    {
                        var img = uploadedImage.Scale(desiredWidth, desiredHeight); // returns System.Drawing.Image file
                        var fullPath = Path.Combine(webRoot, desiredThumbPath);
                        var currentFolder = _fileHandler.GetDirectoryName(fullPath);
                        _fileHandler.CreateDirectory(currentFolder);
                        img.SaveAs(fullPath);
                    }
                }
            }
            
        }
    }
}
