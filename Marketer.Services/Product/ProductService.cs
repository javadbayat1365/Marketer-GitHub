using Marketer.DataLayer.UnitOfWork;
using Marketer.Utilities.Casting;
using Marketer.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketer.Services.Product
{
   public class ProductService:IDisposable
    {
        UnitOfWorkContext _unitOfWork;
        public ProductService() {
           // _unitOfWork = new UnitOfWorkContext();
        }

       

        public async Task<List<ProductModel>> GetAllProduct()
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                var sel =  _unitOfWork.ProductRepository.GetAll().ToProductModel();
                return sel;
            }
        }

        public async Task<ProductModel> Get(long ProductId)
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                var sel = _unitOfWork.ProductRepository.GetByID(ProductId).Cast<ProductModel>();
                return sel;
            }
        }

        public async Task<bool> DeleteById(long ProductId)
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                var sel = _unitOfWork.ProductRepository.Delete(ProductId);
                return sel;
            }
        }

        public async Task<bool> InsertProduct(ProductModel product)
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                var sel = _unitOfWork.ProductRepository.Insert(product.Cast<DomainClasses.Product.Product>());
                return sel;
            }
        }

        public async Task<bool> UpdateProduct(ProductModel product)
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                var sel = _unitOfWork.ProductRepository.Update(product.Cast<DomainClasses.Product.Product>());
                return sel;
            }
        }

        public async void Save()
        {
            using (_unitOfWork = new UnitOfWorkContext())
            {
                _unitOfWork.Save();
            }
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

       
        
    }
}
