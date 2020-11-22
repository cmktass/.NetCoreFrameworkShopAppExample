using System.Collections.Generic;

namespace shopapp.entity
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<ProductCategory> productCategories { get; set; }
    }
}