using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.BusinessEntities;
using WebShop.BusinessServices;

namespace WebShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _productServices.GetAllProducts();
            return View(products.ToList());
        }

        public ActionResult Details(int id)
        {
            ProductEntity product = _productServices.GetProductById(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductEntity product = _productServices.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Stock,IsActive")] ProductEntity product)
        {

            if (ModelState.IsValid)
            {
                _productServices.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }
    }
}