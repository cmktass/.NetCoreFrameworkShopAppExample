using System.Collections.Generic;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class EfCoreProductRepository : EfCoreGenericRepository<ShopContext, Product>, IProductRepository
    {
        public List<Product> GetPopularProduct()
        {
            throw new System.NotImplementedException();
        }
    }
}