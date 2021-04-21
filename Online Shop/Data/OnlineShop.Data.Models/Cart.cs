namespace OnlineShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using OnlineShop.Data.Common.Models;

    public class Cart : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
