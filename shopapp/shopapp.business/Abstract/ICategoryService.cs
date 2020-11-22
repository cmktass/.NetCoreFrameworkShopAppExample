using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService
    {
           
         Category GetById(int i);

         List<Category> GetAll();

         void create(Category entity);

         void Update(Category entity);

         void Delete(Category entity);
    }
}