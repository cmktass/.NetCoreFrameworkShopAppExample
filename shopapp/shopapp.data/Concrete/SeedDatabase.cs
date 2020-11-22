using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public static class SeedDatabase
    {
        public static void Seed(){
            var context=new ShopContext();

            if(context.Database.GetPendingMigrations().Count()==0){
                
                if(context.Categories.Count()==0){
                    context.Categories.AddRange(Categories);
                }
                if(context.Products.Count()==0){
                context.Products.AddRange(Products);
                context.AddRange(ProductCategories);
                 }
            }
            context.SaveChanges();
        }

        private static Category[] Categories={
            new Category{name="Telefon"},
            new Category{name="Bilgisayar"},
            new Category{name="BeyazEşya"}
        };

         private static Product[] Products={
           new Product{name="Iphone 6",price=2000,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone 6s",price=2500,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone 7",price=3500,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone 8",price=5000,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone SE",price=5500,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone 8Plus",price=6000,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},
           new Product{name="Iphone 7Plus",price=4000,imageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/TeoriV2-103888-27_large.jpg",description="iyi Telefon",isApproved=true},   
        };

        private static ProductCategory[] ProductCategories={
            new ProductCategory(){product=Products[0],category=Categories[0]},
            new ProductCategory(){product=Products[0],category=Categories[1]},
            new ProductCategory(){product=Products[1],category=Categories[0]},
            new ProductCategory(){product=Products[1],category=Categories[1]},
            new ProductCategory(){product=Products[2],category=Categories[0]},
            new ProductCategory(){product=Products[2],category=Categories[1]},
            new ProductCategory(){product=Products[3],category=Categories[0]},
            new ProductCategory(){product=Products[3],category=Categories[1]},
            new ProductCategory(){product=Products[4],category=Categories[0]},
            new ProductCategory(){product=Products[4],category=Categories[1]},
            new ProductCategory(){product=Products[5],category=Categories[0]},
            new ProductCategory(){product=Products[5],category=Categories[1]},
        };




    }
}