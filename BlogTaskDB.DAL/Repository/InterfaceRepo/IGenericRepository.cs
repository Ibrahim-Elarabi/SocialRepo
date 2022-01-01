using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.InterfaceRepo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        List<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();
        List<TEntity> GetAll(int page = 1, int pageSize = 10);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        bool CheckExist(Expression<Func<TEntity, bool>> predicate);
        void RemoveFound(Expression<Func<TEntity, bool>> predicate);
        void MakeReadOnly(TEntity entity);
        void MakeReadOnlyRange(IEnumerable<TEntity> entities);
        bool Save();
    }
}
