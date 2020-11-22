namespace shopapp.entity
{
    public class ProductCategory
    {
        public int categoryId { get; set; } 

        public Category category { get; set; }

        public int productId { get; set; }

        public Product product { get; set; }
    }
}