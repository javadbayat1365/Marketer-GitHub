using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marketer.DataLayer.Context;
using Marketer.DomainClasses.Product;
using Marketer.DataLayer.UnitOfWork;
using Marketer.Services.Product;
using Marketer.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Marketer.App.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Authorize]
    //[Route("api/admin/product")]
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<JsonResult> GetAllProduct()
        {
                var sel = await _service.GetAllProduct();
                return Json(new { data = sel });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> GetAllProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var sel = await _service.GetAllProduct();
                return Json(new { data = sel });
            }
            return null;
        }
        [HttpGet]
        public JsonResult GetById(long ProductId)
        {
            var sel = _service.Get(ProductId);
                return Json(new { data = sel});
        }

        [HttpDelete]
        public JsonResult DeleteById(long ProductId)
        {
                var sel = _service.DeleteById(ProductId);
                _service.Save();
                return Json(new { data = sel });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult InsertProduct([Bind("ProductID,Name,RegisterDate,CategoryID,UnitID,CompanyID")] ProductModel product,IFormFile ImgUp)
        {
            if (ModelState.IsValid)
            {
                using (ProductService service = new ProductService())
                {
                    if (ImgUp != null)
                    {

                    }
                    _service.InsertProduct(product);
                    _service.Save();
                }
                return Json(new { data = "ok" });
            }
            else
            {
                return Json(new { data = ModelState.ErrorCount });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateProduct([Bind("ProductID,Name,RegisterDate,CategoryID,UnitID,CompanyID")] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                using (ProductService service = new ProductService())
                {
                    _service.UpdateProduct(product);
                    _service.Save();
                }
                return Json(new { data = "ok" });
            }
            else
            {
                return Json(new { data = ModelState.ErrorCount });
            }
        }
    }
}
