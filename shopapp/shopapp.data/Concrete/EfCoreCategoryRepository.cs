using System.Collections.Generic;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class EfCoreCategoryRepository :EfCoreGenericRepository<ShopContext,Category>,ICategoryRepository
    {
            
    }
}