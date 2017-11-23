using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NotificationBackend.Services
{
    public interface INotificationServiceRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleWhere(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAllIncouding(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveWhere(Expression<Func<TEntity, bool>> predicate);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRangeWhere(IEnumerable<TEntity> entities, Expression<Func<TEntity, bool>> predicate);

        bool Save();        
    }
}
