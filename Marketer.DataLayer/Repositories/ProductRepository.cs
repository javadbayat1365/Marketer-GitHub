using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Marketer.DataLayer.Context;
using Marketer.DomainClasses.Product;

namespace Marketer.DataLayer.Repositories
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        private MarketerDbContext DbContext;
        public ProductRepository(MarketerDbContext marketerDbContext):base(marketerDbContext)
        {
            DbContext = marketerDbContext;
        }
        public bool Delete(object Id)
        {
           return base.Delete(Id);
        }

        public bool Delete(Product entity)
        {
            return base.Delete(entity);
        }

        public  List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            try
            {
                    return  base.GetAll(expression);
               
            }
            catch (Exception w)
            {
                return null;
            }
        }

        public Product GetByID(object Id)
        {
            try
            {
                return base.GetByID(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Product entity)
        {
            return base.Insert(entity);
        }

        public bool Update(Product entity)
        {
            return base.Update(entity);
        }
    }
}
