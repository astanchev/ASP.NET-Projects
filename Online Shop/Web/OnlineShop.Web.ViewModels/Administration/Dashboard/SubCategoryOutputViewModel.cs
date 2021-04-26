namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class SubCategoryOutputViewModel : SubCategoryInputViewModel, IMapFrom<SubCategory>
    {
        public int Id { get; set; }
    }
}
