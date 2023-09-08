using ITB.Kusys.Cse.Project.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace ITB.Kusys.Cse.Project.Core.DataAccess
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        IQueryable<TEntity> Queryable();
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
    }
}
