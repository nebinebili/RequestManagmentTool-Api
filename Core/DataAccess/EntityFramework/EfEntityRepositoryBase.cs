using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext ctex)
        {
            _context = ctex;
        }

        public void Add(TEntity entity)
        {
            
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
           
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return _context.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            
                return filter == null
                    ? _context.Set<TEntity>()
                    : _context.Set<TEntity>().Where(filter);
            
        }

        public void Update(TEntity entity)
        {
            
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
               _context.SaveChanges();
            
        }
    }
}
