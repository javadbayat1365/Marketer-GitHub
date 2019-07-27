using Marketer.DataLayer.Context;
using Marketer.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketer.DataLayer.UnitOfWork
{
   public class UnitOfWorkContext :IDisposable
    {
        private MarketerDbContext _MarketerDbContext;
        public UnitOfWorkContext()
        {
            if (_MarketerDbContext == null)
            {
                _MarketerDbContext = new MarketerDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<MarketerDbContext>());
            }
        }

        private IProductRepository productRepository;
        public IProductRepository ProductRepository {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_MarketerDbContext);
                }
                return productRepository;
            }
        }


        public void Save()
        { 
            _MarketerDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _MarketerDbContext.Dispose();
        }
    }
}
