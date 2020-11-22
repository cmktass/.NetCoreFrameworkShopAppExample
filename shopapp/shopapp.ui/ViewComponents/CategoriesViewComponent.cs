using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.ui.Data;
using shopapp.ui.Model;

namespace shopapp.ui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(){

                 var categories=CategoryRepository.Categories;
                 ViewBag.SelectedCategory=RouteData?.Values["id"];
                 return View(categories);
        }
    }
}