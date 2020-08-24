using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Data.DTOs;
using Data.DTOs.FordAdmin;
using Data.Helpers.Paging;
using Data.Models;

namespace BiotecsBack.Repositories.Abstractions
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> GetByIdForAdminAsync(int productId, CancellationToken token);

        Task<PagedList<AdminProductDto>> GetPagedListForAdminAsync(PageOptions options, CancellationToken token);

        Task<ProductDto> GetByIdAsync(int productId, string language, CancellationToken token);

        Task<PagedList<ProductDto>> GetPagedListAsync(PageOptions options, string language, CancellationToken token);

        Task<IEnumerable<Product>> GetListForUpdateAsync(Expression<Func<Product, bool>> predicate, CancellationToken token);
    }
}
