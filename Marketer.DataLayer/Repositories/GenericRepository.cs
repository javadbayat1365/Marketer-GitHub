using Marketer.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketer.DataLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MarketerDbContext _DbContext;
        private DbSet<T> _dbset;

        public GenericRepository(MarketerDbContext marketerDbContext)
        {
            _DbContext = marketerDbContext;
            _dbset = marketerDbContext.Set<T>();
        }

        public virtual bool Delete(object Id)
        {
            try
            {
                using (_DbContext)
                {

                }
                var sel = _dbset.Find(Id);
                _dbset.Remove(sel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                if (_DbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbset.Attach(entity);
                }
                _dbset.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> where = null)
        {

            try
            {
                IQueryable<T> query = _dbset;
                if (where != null)
                {
                    query = query.Where(where);
                }
               return query.ToList();
            }
            catch (Exception w)
            {
                return null;
            }
        }

        public virtual T GetByID(object Id)
        {
            try
            {
                return _dbset.Find(Id);
            }
            catch (Exception w)
            {

                return null;
            }
           
        }

        public virtual bool Insert(T entity)
        {
            try
            {
                _dbset.Add(entity);
                return true;
            }
            catch (Exception w)
            {
                return false;
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                _DbContext.Attach(entity);
                _DbContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
