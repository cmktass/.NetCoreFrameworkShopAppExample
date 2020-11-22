using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.ui.Data;
using shopapp.ui.Model;

namespace shopapp.ui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {

        private ICategoryService iCategoryService;

        public CategoriesViewComponent(ICategoryService iCategoryService)
        {
            this.iCategoryService=iCategoryService;
        }
        public IViewComponentResult Invoke(){

                 var categories=iCategoryService.GetAll();
                 ViewBag.SelectedCategory=RouteData?.Values["id"];
                 return View(categories);
        }
    }
}