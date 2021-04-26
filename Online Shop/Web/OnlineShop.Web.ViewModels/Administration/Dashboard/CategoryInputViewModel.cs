namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public IList<SubCategoryInputViewModel> SubCategories { get; set; }
    }
}
