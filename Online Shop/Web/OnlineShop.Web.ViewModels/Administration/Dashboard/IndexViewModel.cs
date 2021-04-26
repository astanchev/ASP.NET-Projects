namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<CategoryOutputViewModel> Categories { get; set; }
    }
}
