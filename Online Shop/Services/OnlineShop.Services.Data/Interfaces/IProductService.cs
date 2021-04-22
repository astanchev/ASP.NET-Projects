namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public interface IProductService
    {
        Task<Product> GetByName(string productName);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<bool> DeleteProduct(string productName);
    }
}
