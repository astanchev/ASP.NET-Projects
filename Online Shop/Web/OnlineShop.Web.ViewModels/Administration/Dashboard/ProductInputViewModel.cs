namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Models;

    public class ProductInputViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [RegularExpression(@"(https?:\/\/[^ ]*\.(?:gif|png|jpg|jpeg))")]
        public string ImageUrl { get; set; }

        [Range(typeof(decimal), "0.01", "10000.00")]
        public decimal Price { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(20)]
        public string Size { get; set; }

        public string SubCategory { get; set; }
    }
}
