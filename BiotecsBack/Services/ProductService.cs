using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BiotecsBack.Repositories.Abstractions;
using Data.DTOs;
using Data.DTOs.FordAdmin;
using Data.Helpers.Paging;
using Data.Models;

namespace BiotecsBack.Services
{


    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;

        public ProductService(IProductRepository productRepository, IPhotoService photoService)
        {
            _productRepository = productRepository;
            _photoService = photoService;
        }
        public async Task<ProductDto> GetByIdAsync(int productId, string language, CancellationToken token)
        {
            return await _productRepository.GetByIdAsync(productId, language, token);
        }

        public Task<PagedList<ProductDto>> GetPagedListAsync(PageOptions options, string language, CancellationToken token)
        {
            return _productRepository.GetPagedListAsync(options, language, token);
        }

        public async Task PostProduct(AdminProductDto productDto, string currentFolder, CancellationToken token)
        {
            var newProduct = new Product(productDto);
            if (productDto.Photo != null)
            {
                var imgName = await _photoService.UploadPhoto(productDto.Photo, currentFolder);
                _photoService.ResizeImage(productDto.Photo, Path.Combine(currentFolder, "Thumbs", imgName),100);
                newProduct.AddOrUpdatePhoto(imgName);
            }
            _productRepository.Create(newProduct);
            await _productRepository.SaveAsync(token);
        }

        public async Task DeleteProduct(int id, string currentFolder, CancellationToken token)
        {
            var existingProduct = await _productRepository.GetByIdForAdminAsync(id, token);
            if (existingProduct != null)
            {
                var photoToDelete = existingProduct.ProductPhoto?.FileName;
                if (!string.IsNullOrWhiteSpace(photoToDelete))
                {
                    _photoService.DeleteFile(photoToDelete, currentFolder);
                }
                
                _productRepository.Delete(existingProduct);
                await _productRepository.SaveAsync(token);
            }
        }

        public async Task PutProduct(int id, AdminProductDto productDto, string currentFolder, CancellationToken token)
        {
            var existingProduct = await _productRepository.GetByIdForAdminAsync(id,token);
            var oldFileName = existingProduct.ProductPhoto.FileName;
            _photoService.DeleteFile(oldFileName, currentFolder);

            existingProduct.UpdateProduct(productDto);
            if (productDto.Photo != null)
            {
                var imgName = await _photoService.UploadPhoto(productDto.Photo, currentFolder);
                _photoService.ResizeImage(productDto.Photo, Path.Combine(currentFolder, "Thumbs", imgName), 100);
                existingProduct.AddOrUpdatePhoto(imgName);
            }
            _productRepository.Update(existingProduct);
            await _productRepository.SaveAsync(token);
        }

        public async Task<PagedList<AdminProductDto>> GetPagedListForAdminAsync(PageOptions options, CancellationToken token)
        {
            return await _productRepository.GetPagedListForAdminAsync(options, token);
        }

        public async Task<AdminProductDto> GetByIdForAdminAsync(int productId, CancellationToken token)
        {
            var product =await _productRepository.GetByIdForAdminAsync(productId, token);
            return product?.ToAdminDto();
        }
    }
}
