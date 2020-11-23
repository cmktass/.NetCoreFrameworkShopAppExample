using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
         List<Product> GetPopularProduct();

         Product GetProductDetails(int id);

         List<Product> GetProductByCategoryId(int categoryId,int page,int pageSize);

         int getCountByCategory(int id);

         List<Product> GetAllwithPage(int page,int pageSize);

         int getAllCount();
         
    }
}