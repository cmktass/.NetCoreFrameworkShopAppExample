using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository iCategoryRepository;

        public CategoryManager(ICategoryRepository _iCategoryRepository)
        {
            this.iCategoryRepository=_iCategoryRepository;
        }
        public void create(Category entity)
        {
           iCategoryRepository.create(entity);
        }

        public void Delete(Category entity)
        {
            iCategoryRepository.Delete(entity);
        }

        public void deleteFromCategory(int categoryId, int productId)
        {
            iCategoryRepository.deleteFromCategory(categoryId,productId);
        }

        public List<Category> GetAll()
        {
            return iCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return iCategoryRepository.GetById(id);
        }

        public Category GetByIdCategoryWithProducts(int id)
        {
            return iCategoryRepository.GetByIdCategoryWithProducts(id);
        }

        public void Update(Category entity)
        {
            iCategoryRepository.Update(entity);
        }
    }
}