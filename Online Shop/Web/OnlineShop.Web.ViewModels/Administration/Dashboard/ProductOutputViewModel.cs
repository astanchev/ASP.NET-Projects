namespace OnlineShop.Web.ViewModels.Administration.Dashboard
{
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class ProductOutputViewModel : ProductInputViewModel, IMapFrom<Product>
    {
        public int Id { get; set; }
    }
}
