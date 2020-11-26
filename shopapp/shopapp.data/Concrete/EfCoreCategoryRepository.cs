using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<ShopContext, Category>, ICategoryRepository
    {
        public void deleteFromCategory(int categoryId, int productId)
        {
           using(var db=new ShopContext())
           {
                string sorgu="delete from productcategory where productId=@p0 and categoryId=@p1";
                db.Database.ExecuteSqlRaw(sorgu,productId,categoryId);
           }
        }

        public Category GetByIdCategoryWithProducts(int id)
        {
            using(var db=new ShopContext()){
                var category=db.Categories.Where(i=>i.id==id)
                                            .Include(i=>i.productCategories)
                                            .ThenInclude(i=>i.product).FirstOrDefault();
                return category;
            }
            
        }
    }
}