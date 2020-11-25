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
            throw new System.NotImplementedException();
        }

        public void Delete(Category entity)
        {
            iCategoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return iCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return iCategoryRepository.GetById(id);
        }

        public void Update(Category entity)
        {
            iCategoryRepository.Update(entity);
        }
    }
}