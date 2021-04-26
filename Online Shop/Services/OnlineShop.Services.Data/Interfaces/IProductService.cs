namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public interface IProductService
    {
        Task<Product> GetByName(string productName);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> CreateProduct(ProductInputViewModel productInput);

        Task<Product> UpdateProduct(ProductInputViewModel productInput);

        Task DeleteProduct(string productName);
    }
}
