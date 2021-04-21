namespace OnlineShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<SubCategoryCategory> SubCategoryCategories { get; set; } = new HashSet<SubCategoryCategory>();
    }
}
