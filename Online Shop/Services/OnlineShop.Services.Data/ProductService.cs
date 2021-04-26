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
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly ISubCategoryService subCategoryService;

        public ProductService(
            IDeletableEntityRepository<Product> productRepository,
            ISubCategoryService subCategoryService)
        {
            this.productRepository = productRepository;
            this.subCategoryService = subCategoryService;
        }

        public async Task<Product> CreateProduct(ProductInputViewModel productInput)
        {
            var subCategory = await this.subCategoryService
                                        .GetByName(productInput.SubCategory);

            Product product = new Product
            {
                Name = productInput.Name,
                Description = productInput.Description,
                Gender = productInput.Gender,
                ImageUrl = productInput.ImageUrl,
                Price = productInput.Price,
                Size = productInput.Size,
                SubCategory = subCategory,
            };

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

        public async Task<Product> UpdateProduct(ProductInputViewModel productInput)
        {
            var subCategory = await this.subCategoryService
                                        .GetByName(productInput.SubCategory);

            Product product = new Product
            {
                Name = productInput.Name,
                Description = productInput.Description,
                Gender = productInput.Gender,
                ImageUrl = productInput.ImageUrl,
                Price = productInput.Price,
                Size = productInput.Size,
                SubCategory = subCategory,
            };

            this.productRepository.Update(product);
            await this.productRepository.SaveChangesAsync();

            return product;
        }
    }
}
