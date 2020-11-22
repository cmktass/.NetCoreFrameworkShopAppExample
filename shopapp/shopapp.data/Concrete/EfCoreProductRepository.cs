using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class EfCoreProductRepository : EfCoreGenericRepository<ShopContext, Product>, IProductRepository
    {
        public List<Product> GetPopularProduct()
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
              using(var db=new ShopContext()){
               var products=db.Products.AsQueryable();
               if(categoryId>0){
                    products=products.Include(i=>i.productCategories)
                                        .ThenInclude(i=>i.category)
                                        .Where(i=>i.productCategories.Any(a=>a.category.id==categoryId));
               }
               return products.ToList();
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