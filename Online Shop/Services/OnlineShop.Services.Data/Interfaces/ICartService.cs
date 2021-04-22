namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public interface ICartService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<IEnumerable<Product>> AddProduct(string productName);

        Task<IEnumerable<Product>> RemoveProduct(string productName);

        Task<bool> ClearAllProducts();
    }
}
