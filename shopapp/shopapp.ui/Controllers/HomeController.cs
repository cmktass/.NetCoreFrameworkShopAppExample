using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.ui.Model;

namespace shopapp.ui.Controllers
{
    public class HomeController:Controller
    {

        private IProductRepository iproductService;

        public HomeController(IProductRepository productService)
        {
            this.iproductService=productService;
        }
        public IActionResult Index(int page=1){


                const int pageSize=3;
                var productList=iproductService.GetAllwithPage(page,pageSize);
                PageInfo p=new PageInfo(){
                   totalItems=iproductService.getAllCount(),
                   currentPage=page,
                   itemPerPage=pageSize,
                   currentCategory= 0
                };
                ViewBag.p=p;
                return View(productList);
        }
    }
}