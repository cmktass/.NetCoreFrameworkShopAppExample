using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.business.Abstract;
using shopapp.business.Concrete;
using shopapp.data.Abstract;
using shopapp.data.Concrete;
using shopapp.ui.Identity;

namespace shopapp.ui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

           //For IDENTITY

           services.AddDbContext<ApplicationContext>(options=>options.UseSqlite("Data Source=shopDb"));        
           services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders(); 
           services.Configure<IdentityOptions>(options=>{
               

               
               options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(5);
               options.Lockout.AllowedForNewUsers=true;

               options.User.RequireUniqueEmail=true;
               options.SignIn.RequireConfirmedEmail=true;
               options.SignIn.RequireConfirmedPhoneNumber=false;
           });

           services.ConfigureApplicationCookie(options=>{
               options.LoginPath="/account/login";
               options.LogoutPath="/account/logout";
               options.AccessDeniedPath="/account/accessdenied";
               options.SlidingExpiration=true;

               options.Cookie=new CookieBuilder{
                   HttpOnly=true,
                   Name=".ShopApp.Security.Cookie"
               };
           });


            //IoC Container For Dependency Injection
            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService,CategoryManager>();

            services.AddScoped<IProductRepository,EfCoreProductRepository>();
            services.AddScoped<IProductService,ProductManager>();
            

            services.AddControllersWithViews();  //ASPNET TE MVC YAPISINI KULLANILACAĞINI BELİRTİR.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions{
                FileProvider=new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
                    RequestPath="/modules"
            });


            app.UseAuthentication(); //For IDENTİTY
            
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints=>{        //MVC ROUTE İŞLEMLERİ
                
                endpoints.MapControllerRoute(
                    name:"products",
                    pattern:"products",
                    defaults: new {controller="Product",action="list"}
                );
                           
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );
            });
            


        }
    }
}
