using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NotificationBackend.Services;
using NotificationBackend.DAL.NotificationEntities;

namespace NoficationBackend.Services
{
    public class NotificationServiceRepository<TEntity> : INotificationServiceRepository<TEntity> where TEntity : class
    {
        protected readonly NotifContext _dbContext;

        public NotificationServiceRepository(NotifContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

 
        public virtual IEnumerable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }
        public virtual int Count()
        {
            return _dbContext.Set<TEntity>().Count();
        }

        public virtual IEnumerable<TEntity> GetAllIncouding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);

        }
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity GetSingleWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(predicate);
        }
        public TEntity GetSingleIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveRangeWhere(IEnumerable<TEntity> entities, Expression<Func<TEntity, bool>> predicate)
        {
            // return _dbContext.Set<TEntity>().Where(predicate).RemoveRange(entities);
        }

        public void RemoveWhere(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = _dbContext.Set<TEntity>().Where(predicate);

            foreach (var entity in entities)
            {
                _dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            }
        }
        public virtual void Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

    }
}
