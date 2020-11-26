using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductRepository iproductRepository;
        public ProductManager(IProductRepository _iproductRepository)
        {
            this.iproductRepository=_iproductRepository;
        }
        public void create(Product entity)
        {
            iproductRepository.create(entity);
        }

        public void createProductWithCategories(Product product, int[] categoryIds)
        {
           iproductRepository.createProductWithCategories(product,categoryIds);
        }

        public void Delete(Product entity)
        {
            iproductRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return iproductRepository.GetAll();
        }

        public int getAllCount()
        {
           return iproductRepository.getAllCount();
        }

        public List<Product> GetAllwithPage(int page, int pageSize)
        {
            return iproductRepository.GetAllwithPage(page,pageSize);
        }

        public Product GetById(int i)
        {
             return iproductRepository.GetById(i);
        }

        public Product getByProductWithCategories(int id)
        {
            return iproductRepository.getByProductWithCategories(id);
        }

        public int getCountByCategory(int? id)
        {
           return iproductRepository.getCountByCategory((int)id);
        }

        public Product getProductDetails(int id)
        {
            return iproductRepository.GetProductDetails(id);
        }

        public List<Product> getProductsByCategoryId(int categoryId,int page,int pageSize)
        {
            return iproductRepository.GetProductByCategoryId(categoryId,page,pageSize);
        }

        public void Update(Product entity)
        {
           iproductRepository.Update(entity);
        }

        public void Update(Product entity, int[] categoryId)
        {
            iproductRepository.Update(entity,categoryId);
        }
    }
}