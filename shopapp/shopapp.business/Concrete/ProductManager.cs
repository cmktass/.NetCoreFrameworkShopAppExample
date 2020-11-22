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
            throw new System.NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return iproductRepository.GetAll();
        }

        public Product GetById(int i)
        {
             return iproductRepository.GetById(i);
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}