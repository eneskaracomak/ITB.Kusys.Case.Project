using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using ITB.Kusys.Cse.Project.DataAccess.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ITB.Kusys.Cse.Project.Core.DataAccess
{
    public class EfRepositoryBase<TEntity, TContext> : RepositoryBase,IBaseRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new()
    {

        private readonly DbSet<TEntity> _objectSet;

        protected EfRepositoryBase()
        {
            _objectSet = context.Set<TEntity>();
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public IQueryable<TEntity> Queryable()
        {
            return _objectSet.AsQueryable<TEntity>();

        }

        public int Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

    }
}
