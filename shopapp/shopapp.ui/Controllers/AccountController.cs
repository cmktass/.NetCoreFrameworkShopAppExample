using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shopapp.ui.Identity;
using shopapp.ui.Model;

namespace shopapp.ui.Controllers
{
    public class AccountController:Controller
    {

        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager=userManager;
            this.signInManager=signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
         public async Task<IActionResult> Login(LoginModel loginModel)
        {
           if(!ModelState.IsValid)
           {
               return View(loginModel);
           }
           var user=await userManager.FindByNameAsync(loginModel.UserName);
           if(user==null)
           {
               ViewBag.ErrorMessage="Error Mesajı";
           }
           var result=await signInManager.PasswordSignInAsync(loginModel.UserName,loginModel.Password,false,false);

           if(result.Succeeded)
           {
               return RedirectToAction("Index","Home");
           }
            return View();
        }

         public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
         public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            Console.WriteLine(model.Email);
            Console.WriteLine(model.FirstName);
            var user=new User(){
                FirstName=model.FirstName,
                LastName=model.LastName,
                Email=model.Email,
                UserName=model.UserName
            };
            var result=await userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                var code=await userManager.GenerateEmailConfirmationTokenAsync(user);
                var url=Url.Action("ConfirmEmail","Account",new{
                    userId=user.Id,
                    token=code
                });
                return RedirectToAction("Login","Account");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            
            return View();
        }
    }

  
}