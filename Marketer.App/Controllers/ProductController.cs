using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketer.Services.Product;
using Marketer.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Marketer.App.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<JsonResult> GetAllProduct()
        {
           
                var sel = await _service.GetAllProduct();
                return Json(new { data = sel });
            
        }
        [HttpPost]
        public async Task<JsonResult> GetAllProduct(ProductModel product)
        {
                var sel = await _service.GetAllProduct();
                return Json(new { data = sel });
            
        }
        [HttpPost]
        public async Task<JsonResult> GetById(long ProductId)
        {
                var sel =await _service.Get(ProductId);
                return Json(new { data = sel });
            
        }
    }
}