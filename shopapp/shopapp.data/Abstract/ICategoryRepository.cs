using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdCategoryWithProducts(int id);
        void deleteFromCategory(int categoryId, int productId);
        void Update(Category entity);
    }
}