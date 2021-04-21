namespace OnlineShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SubCategoryCategory
    {
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
