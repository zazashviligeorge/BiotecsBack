using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BiotecsBack.Data;
using Data.Helpers.Paging;
using Microsoft.EntityFrameworkCore;

namespace BiotecsBack.Repositories.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext;

        public RepositoryBase(ApplicationDbContext repositoryContext) { RepositoryContext = repositoryContext; }

        public virtual void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public virtual void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public virtual void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public async Task<int> SaveAsync(CancellationToken t)=> await RepositoryContext.SaveChangesAsync(t);

       
    }
}
