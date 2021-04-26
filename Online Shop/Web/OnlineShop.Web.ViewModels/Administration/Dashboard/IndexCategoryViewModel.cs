namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class IndexCategoryViewModel
    {
        public IEnumerable<CategoryOutputViewModel> Categories { get; set; }
    }
}
