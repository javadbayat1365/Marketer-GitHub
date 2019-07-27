using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marketer.DataLayer.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        List<T> GetAll(Expression<Func<T,bool>> expression=null);
        T GetByID(object Id);
        bool Delete(object Id);
        bool Delete(T entity);
        bool Update(T entity);
        bool Insert(T entity);
    }
}
