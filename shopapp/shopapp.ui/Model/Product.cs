namespace shopapp.ui.Model
{
    public class Product
    {
        public int id { get; set; }         

        public string  name { get; set; }

        public string description { get; set; } 

        public double price { get; set; }   

        public bool isApproved {get; set;}

        public string imageUrl { get; set; }

        public int categoryId { get; set; }
        
    }
}