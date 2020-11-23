using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class EfCoreProductRepository : EfCoreGenericRepository<ShopContext, Product>, IProductRepository
    {
        public int getAllCount()
        {
            using(var db=new ShopContext()){
                int productCount=db.Products.Count();
                return productCount;
            }
        }

        public List<Product> GetAllwithPage(int page, int pageSize)
        {
            using(var db=new ShopContext()){
                var products=db.Products.Skip((page-1)*pageSize).Take(pageSize).ToList();
                return products;
            }
        }

        public int getCountByCategory(int ids)
        {
            using(var db=new ShopContext()){
               var products=db.Products.AsQueryable();
               if(ids>0){
                    products=products.Include(i=>i.productCategories)
                                        .ThenInclude(i=>i.category)
                                        .Where(i=>i.productCategories.Any(a=>a.category.id==ids));
               }
               return products.Count();
            }
        }
        public List<Product> GetPopularProduct()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProductByCategoryId(int categoryId,int page,int pageSize)
        {
              using(var db=new ShopContext()){
               var products=db.Products.AsQueryable();
               if(categoryId>0){
                    products=products.Include(i=>i.productCategories)
                                        .ThenInclude(i=>i.category)
                                        .Where(i=>i.productCategories.Any(a=>a.category.id==categoryId));
               }
               return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
           }
        }

        public Product GetProductDetails(int id)
        {
            using(var db=new ShopContext()){
                return db.Products.Where(i=>i.id==id)
                                    .Include(i=>i.productCategories)
                                    .ThenInclude(i=>i.category)
                                    .FirstOrDefault();
            }
        }
    }
}