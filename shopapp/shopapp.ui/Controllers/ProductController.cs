using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.ui.Data;
using shopapp.ui.Model;
using shopapp.ui.ViewsModel;

namespace shopapp.ui.Controllers
{
    public class ProductController:Controller
    {

        private IProductService iProductService;

        public ProductController(IProductService _iProductService)
        {
            this.iProductService=_iProductService;
        }

        public IActionResult list(int? id,int page=1){

            const int pageSize=3;
            var products=iProductService.GetAllwithPage(page,pageSize);
            PageInfo p=new PageInfo(){
                   totalItems=iProductService.getAllCount(),
                   currentPage=page,
                   itemPerPage=pageSize,
                   currentCategory= 0
            };
            
            if(id!=null){
                 p=new PageInfo(){
                   totalItems=iProductService.getCountByCategory(id),
                   currentPage=page,
                   itemPerPage=pageSize,
                   currentCategory= (int)id
            };
               products=iProductService.getProductsByCategoryId((int)id,page,pageSize); 
           }
            ViewBag.p=p;
           return View(products);
        }
        public IActionResult details(int id){

            var product=iProductService.getProductDetails(id);
            return View(product);

        }
    }
}