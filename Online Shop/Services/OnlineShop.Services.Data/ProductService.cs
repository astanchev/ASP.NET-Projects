namespace OnlineShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OnlineShop.Data.Common.Repositories;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Data.Interfaces;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProduct(string productName)
        {
            Product product = await this.GetByName(productName);

            this.productRepository.Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.productRepository
                        .All()
                        .ToListAsync();
        }

        public async Task<Product> GetByName(string productName)
        {
            return await this.productRepository
                        .All()
                        .FirstOrDefaultAsync(c => c.Name == productName);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            this.productRepository.Update(product);
            await this.productRepository.SaveChangesAsync();

            return product;
        }
    }
}
