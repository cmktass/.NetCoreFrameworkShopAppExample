using Microsoft.AspNetCore.Mvc;
using shopapp.data.Abstract;
using shopapp.ui.Model;

namespace shopapp.ui.Controllers
{
    public class HomeController:Controller
    {

        private IProductRepository iproductRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.iproductRepository=productRepository;
        }
        public IActionResult Index(){
           
                var pr=iproductRepository.GetAll();
                return View(pr);
        }
    }
}