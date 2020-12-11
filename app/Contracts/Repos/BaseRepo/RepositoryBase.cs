using System;
using System.Linq;
using System.Linq.Expressions;
using app.Data;
using Microsoft.EntityFrameworkCore;

namespace app.Contracts.Repos.BaseRepo
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class

    {
        private RepositoryContext RepositoryContext { get; set; }

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> Expression)
        {
            return RepositoryContext.Set<T>().Where(Expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }
    }
}