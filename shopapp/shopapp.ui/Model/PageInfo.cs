using System;

namespace shopapp.ui.Model
{
    public class PageInfo
    {
        public int totalItems { get; set; }

        public int itemPerPage { get; set; }

        public int currentPage { get; set; }

        public int currentCategory { get; set; }

        public int totalPages(){
            decimal deger= (decimal)totalItems/itemPerPage;
            return (int)Math.Ceiling(deger);
        }
    }
}