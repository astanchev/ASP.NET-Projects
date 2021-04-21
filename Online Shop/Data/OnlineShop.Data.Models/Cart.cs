namespace OnlineShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; } = new HashSet<CartProduct>();
    }
}
