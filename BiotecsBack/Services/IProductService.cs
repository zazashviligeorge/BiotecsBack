using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data.DTOs;
using Data.DTOs.FordAdmin;
using Data.Helpers.Paging;
using Microsoft.AspNetCore.Http;

namespace BiotecsBack.Services
{
    public interface IProductService
    {
        Task<PagedList<AdminProductDto>> GetPagedListForAdminAsync(PageOptions options, CancellationToken token);
        Task<AdminProductDto> GetByIdForAdminAsync(int productId, CancellationToken token);
        Task<ProductDto> GetByIdAsync(int productId, string language, CancellationToken token);
        Task DeleteProduct(int id, string currentFolder, CancellationToken token);
        Task PutProduct(int id, AdminProductDto productDto, string currentFolder, CancellationToken token);
        Task<PagedList<ProductDto>> GetPagedListAsync(PageOptions options, string language, CancellationToken token);
        Task PostProduct(AdminProductDto productDto, string currentFolder, CancellationToken token);
    }
}
