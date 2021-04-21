namespace OnlineShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnlineShop.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [RegularExpression(@"(https?:\/\/[^ ]*\.(?:gif|png|jpg|jpeg))")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(typeof(decimal), "0.01", "10000.00")]
        public decimal Price { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(20)]
        public string Size { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; } = new HashSet<CartProduct>();
    }
}
