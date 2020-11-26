using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService
    {
           
         Category GetById(int id);

         List<Category> GetAll();

         void create(Category entity);

         void Update(Category entity);

         void Delete(Category entity);
        Category GetByIdCategoryWithProducts(int id);
        
        void deleteFromCategory(int categoryId, int productId);
    }
}