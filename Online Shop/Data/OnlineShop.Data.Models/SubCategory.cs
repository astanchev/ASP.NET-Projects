namespace OnlineShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class SubCategory : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Product Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
