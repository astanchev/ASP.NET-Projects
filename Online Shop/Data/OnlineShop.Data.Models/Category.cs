namespace OnlineShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        public Category(List<SubCategory> subCategories)
        {
            this.SubCategories = new HashSet<SubCategory>(subCategories);
        }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
