using BiotecsBack.Data;
using BiotecsBack.Repositories.Abstractions;
using Data.DTOs;
using Data.Helpers.Paging;
using Data.LanguageHelpers;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Data.DTOs.FordAdmin;
using Data.Helpers.Sorting;
using Microsoft.EntityFrameworkCore;

namespace BiotecsBack.Repositories.Concrete
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext ctx) : base(ctx) { }

        public async Task<ProductDto> GetByIdAsync(int productId, string language, CancellationToken token)
        {
            return await LoadRelatedData()
                .Select(MultiLanguageSupport.SingleProductWithCurrentLanguage(language))
                .FirstOrDefaultAsync(c => c.Id == productId, cancellationToken: token);
        }

        public async Task<Product> GetByIdForAdminAsync(int productId, CancellationToken token)
        {
            return await LoadRelatedData()
                .FirstOrDefaultAsync(c => c.Id == productId,cancellationToken:token);
        }

        public async Task<IEnumerable<Product>> GetListForUpdateAsync(Expression<Func<Product, bool>> predicate, CancellationToken token)
        {
            return await LoadRelatedData()
                .Where(predicate)
                .ToListAsync(cancellationToken: token);

        }

        public async Task<PagedList<ProductDto>> GetPagedListAsync(PageOptions options, string language, CancellationToken token)
        {
            var resultQuery = LoadRelatedData();


            //searching
            if (!string.IsNullOrWhiteSpace(options.SearchBy))
            {
                resultQuery = resultQuery.Where(Product.GetSearchQuery(options.SearchBy));
            }

            //filtering
            if (options.GroupId != null)
            {
                resultQuery = resultQuery.Where(c => c.GroupId == options.GroupId);
            }

            if (options.SubstanceId != null)
            {
                resultQuery = resultQuery.Where(c => c.ActiveSubstanceId == options.SubstanceId);
            }


            //sorting
            if (!string.IsNullOrWhiteSpace(options.SortBy))
            {
                resultQuery=resultQuery.ApplySort(options.SortBy);
            }

          

            var resultList = await resultQuery
                .Select(MultiLanguageSupport.ProductWithCurrentLanguage(language))
                .ToListAsync(cancellationToken: token);

            return PagedList<ProductDto>
                .ToPagedList(resultList, options.PageNumber,
                    options.PageSize);

        }

        public async Task<PagedList<AdminProductDto>> GetPagedListForAdminAsync(PageOptions options, CancellationToken token)
        {
            var resultQuery = LoadRelatedData();


            //searching
            if (!string.IsNullOrWhiteSpace(options.SearchBy))
            {
                resultQuery = resultQuery.Where(Product.GetSearchQuery(options.SearchBy));
            }

            //filtering
            if (options.GroupId != null)
            {
                resultQuery = resultQuery.Where(c => c.GroupId == options.GroupId);
            }

            if (options.SubstanceId != null)
            {
                resultQuery = resultQuery.Where(c => c.ActiveSubstanceId == options.SubstanceId);
            }


            //sorting
            if (!string.IsNullOrWhiteSpace(options.SortBy))
            {
                resultQuery = resultQuery.ApplySort(options.SortBy);
            }



            var resultList = await resultQuery
                .Select(c=>c.ToAdminDto())
                .ToListAsync(cancellationToken: token);

            return PagedList<AdminProductDto>
                .ToPagedList(resultList, options.PageNumber,
                    options.PageSize);

        }

        private IQueryable<Product> LoadRelatedData()
        {
            IQueryable<Product> resultQuery = RepositoryContext.Products
                .Include(q => q.Group)
                .Include(x => x.ActiveSubstance);
            return resultQuery.AsQueryable();
        }
    }

}
