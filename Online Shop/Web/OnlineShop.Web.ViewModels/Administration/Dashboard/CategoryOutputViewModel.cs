namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class CategoryOutputViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
