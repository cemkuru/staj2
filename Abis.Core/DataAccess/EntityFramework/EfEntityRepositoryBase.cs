using Abis.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Abis.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly DbSet<TEntity> _dbSet;

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where = null)
        {
            object result;
            if (where != null)
            {
                result = _dbSet.Where(where);
            }
            else
            {
                IQueryable<TEntity> dbset = _dbSet;
                result = dbset;
            }
            return (IQueryable<TEntity>)result;
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> queryable = GetMany(where);

            for (int i = 0; i < include.Length; i++)
            {
                queryable = queryable.Include(include[i]);
            }

            return queryable;
        }

        public IQueryable<TEntity> GetMany( params string[] includes)
        {
            IQueryable<TEntity> query = null;
            foreach(var include in includes)
            {
                query = _dbSet.Include(include);

            }
            return query == null ? _dbSet : query;
        }

        
    }
}
