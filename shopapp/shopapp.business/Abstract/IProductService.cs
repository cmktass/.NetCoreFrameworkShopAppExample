using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService
    {
         
         Product GetById(int i);

         List<Product> GetAll();

         void create(Product entity);

         void Update(Product entity);

         void Delete(Product entity);

         Product getProductDetails(int id);

         List<Product> getProductsByCategoryId(int categoryId,int page,int pageSize);
        int getCountByCategory(int? id);

        List<Product> GetAllwithPage(int page,int pageSize);

        int getAllCount();
    }
}