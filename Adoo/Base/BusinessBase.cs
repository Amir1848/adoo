using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Adoo.Base
{
    public abstract class BusinessBase<TEntity, TViewModel>
        where TEntity : Entity
        where TViewModel : class, new()
    {

        DbContext _dbContext;

        public BusinessBase(DbContext ApplicationDBContext) {
            _dbContext = ApplicationDBContext;
        }


        public virtual IQueryable<TEntity> FetchAll(bool trackChanges = false) => !trackChanges ? _dbContext.Set<TEntity>().AsNoTracking() : _dbContext.Set<TEntity>();
        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool trackChanges = false) => !trackChanges ? _dbContext.Set<TEntity>().Where(expression).AsNoTracking() : _dbContext.Set<TEntity>().Where(expression);
        public virtual long Create(TEntity entity, bool saveChanges = true)
        {
            var res = _dbContext.Set<TEntity>().Add(entity);
            if (saveChanges)
            {
                _dbContext.SaveChanges();
            }
            return res.Entity.Id;
        }
        public virtual void Update(TEntity entity, bool saveChanges = true)
        {
            _dbContext.Set<TEntity>().Update(entity);
            if (saveChanges)
            {
                _dbContext.SaveChanges();
            }
        }
        public virtual void Delete(TEntity entity, bool saveChanges = true)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (saveChanges)
            {
                _dbContext.SaveChanges();
            }
        }

        public virtual TViewModel FetchViewModelByID(long id)
        {
            return FetchByID(id);
        }

        public abstract TViewModel FetchByID(long id);

        public void Delete(long id)
        {
            var entity = Where(p => p.Id == id).Single();
            Delete(entity);
        }

        public TEntity FetchEntityByID(long id)
        {
            return Where(p => p.Id == id).Single();
        }
    }
}
