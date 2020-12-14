using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;

namespace shopapp.ui.Controllers
{
    [Authorize]
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
            var cat=IcategoryService.GetAll();
            return View(cat);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product,int [] categoryIds)
        {
            IproductService.createProductWithCategories(product,categoryIds);
            return RedirectToAction("ProductList");
        }

        public IActionResult edit(int id)
        {
                var product=IproductService.getByProductWithCategories(id);
                ViewBag.Categories=IcategoryService.GetAll();
                return View(product);
        }

        [HttpPost]
        public IActionResult edit(Product p,int [] categoryId)
        {
            IproductService.Update(p,categoryId);
            Console.Write(categoryId[0]);
            return RedirectToAction("ProductList");
        }

        public IActionResult delete(int id)
        {
            var product=IproductService.GetById(id);
            IproductService.Delete(product);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string name)
        {
            Category category=new Category{name=name};
            IcategoryService.create(category);
            return RedirectToAction("categoryList");
        }

         public IActionResult categoryList()
        {
            var categories=IcategoryService.GetAll();
            return View(categories);
        }

        public IActionResult editCategory(int id)
        {
            var category=IcategoryService.GetByIdCategoryWithProducts(id);
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

        [HttpPost]
        public IActionResult deleteFromCategory(int categoryId,int productId)
        {   
            IcategoryService.deleteFromCategory(categoryId,productId);
            Console.WriteLine(categoryId+"    "+productId);
            return Redirect("/admin/editcategory/"+categoryId);
        }

        

    }
}