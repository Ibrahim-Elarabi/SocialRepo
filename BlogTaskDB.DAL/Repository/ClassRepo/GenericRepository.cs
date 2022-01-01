using BlogTask.Data;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.ClassRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly BlogTaskContext  Context;

        public GenericRepository(BlogTaskContext context)
        {
            this.Context = context;
        }
        public virtual TEntity GetByID(int id)
        {
            try
            {
                return Context.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public virtual List<TEntity> GetAll()
        {
            var result = new List<TEntity>();
            try
            {
                result = Context.Set<TEntity>()
                                .ToList();

            }
            catch (Exception e)
            { }
            return result;
        }
        public virtual IQueryable<TEntity> GetAllAsQueryable()
        {

            try
            {
                return Context.Set<TEntity>().AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual List<TEntity> GetAll(int page = 1, int pageSize = 10)
        {
            var result = new List<TEntity>();
            try
            {
                result = Context.Set<TEntity>()
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            }
            catch (Exception e) { }
            return result;
        }
        public virtual List<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var result = new List<TEntity>();
            try
            {
                result = Context.Set<TEntity>()
                                .Where(predicate)
                                .ToList();
            }
            catch (Exception e) { }
            return result;
        }
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().FirstOrDefault(predicate);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public virtual void Add(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
            }
            catch (Exception e) { }
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception e) { }
        }
        public virtual void Remove(TEntity entity)
        {
            try
            {
                var prop = entity.GetType().GetProperty("IsDeleted");
                if (prop != null)
                {
                    prop.SetValue(entity, true);
                    Context.Attach(entity);
                    Context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    Context.Set<TEntity>().Remove(entity);
                }
            }
            catch (Exception e) { }
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
        public virtual void Update(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Attach(entity);
                var entry = Context.Entry(entity);
                entry.State = EntityState.Modified;
            }
            catch (Exception e) { }
        }
        public virtual bool CheckExist(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Context.Set<TEntity>().Any(predicate);

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public virtual void RemoveFound(Expression<Func<TEntity, bool>> predicate)
        {
            var list = Context.Set<TEntity>().Where(predicate).ToList() ?? new List<TEntity>();
            foreach (var entity in list)
            {
                Remove(entity);
            }
        }
        public virtual void MakeReadOnly(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    Context.Entry(entity).State = EntityState.Detached;
                }
            }
            catch (Exception e) { }
        }
        public virtual void MakeReadOnlyRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                MakeReadOnly(entity);
            }
        }

        public bool Save()
        {
            var count = Context.SaveChanges();
            if (count > 0) return true;
            else return false;
        }
    }

}
