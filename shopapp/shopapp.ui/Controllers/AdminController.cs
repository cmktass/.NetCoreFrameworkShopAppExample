using System;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;

namespace shopapp.ui.Controllers
{
    public class AdminController:Controller
    {

        private IProductService IproductService;
        private ICategoryService IcategoryService;
        public AdminController(IProductService iproductService,ICategoryService IcategoryService)
        {
            this.IproductService=iproductService;
            this.IcategoryService=IcategoryService;
        }
        public IActionResult ProductList()
        {
                var products=IproductService.GetAll();
                return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            IproductService.create(product);
            return RedirectToAction("ProductList");
        }

        public IActionResult edit(int id)
        {
                var product=IproductService.GetById(id);
                return View(product);
        }

        [HttpPost]
        public IActionResult edit(Product p)
        {
            IproductService.Update(p);
            return RedirectToAction("ProductList");
        }

        public IActionResult delete(int id)
        {
            var product=IproductService.GetById(id);
            IproductService.Delete(product);
            return RedirectToAction("ProductList");
        }

         public IActionResult categoryList()
        {
            var categories=IcategoryService.GetAll();
            return View(categories);
        }

        public IActionResult editCategory(int id)
        {
            var category=IcategoryService.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult editCategory(Category c)
        {
            IcategoryService.Update(c);
            return RedirectToAction("categoryList");
        }
         public IActionResult deleteCategory(int id)
        {
            var category=IcategoryService.GetById(id);
            IcategoryService.Delete(category);
            return RedirectToAction("categoryList");
        }


    }
}