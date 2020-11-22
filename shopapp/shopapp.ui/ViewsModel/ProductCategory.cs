using System.Collections.Generic;
using shopapp.ui.Model;

namespace shopapp.ui.ViewsModel
{
    public class ProductCategory
    {
        public List<Product> products { get; set; }

        public List<Category> categories { get; set; }
        
    }
}