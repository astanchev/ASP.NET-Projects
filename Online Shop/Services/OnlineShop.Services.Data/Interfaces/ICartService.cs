namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public interface ICartService
    {
        IEnumerable<Product> GetAllProducts(string userId);

        Task<IEnumerable<Product>> AddProduct(string productName, string userId);

        Task<IEnumerable<Product>> RemoveProduct(string productName, string userId);

        Task ClearAllProducts(string userId);
    }
}
