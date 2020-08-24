using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Helpers.Paging;

namespace BiotecsBack.Repositories.Abstractions
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveAsync(CancellationToken t);
    }
}
