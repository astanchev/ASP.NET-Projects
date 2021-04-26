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

    public class SubCategoryService : ISubCategoryService
    {
        private readonly IDeletableEntityRepository<SubCategory> subCategoryRepository;

        public SubCategoryService(IDeletableEntityRepository<SubCategory> subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        public async Task<SubCategory> AddProduct(string subCategoryName, Product product)
        {
            SubCategory subCategory = await this.GetByName(subCategoryName);
            subCategory.Products.Add(product);

            this.subCategoryRepository.Update(subCategory);
            await this.subCategoryRepository.SaveChangesAsync();

            return subCategory;
        }

        public async Task<SubCategory> ChangeSubCategoryName(string subCategoryOldName, string subCategoryNewName)
        {
            SubCategory subCategory = await this.GetByName(subCategoryOldName);
            subCategory.Name = subCategoryNewName;

            this.subCategoryRepository.Update(subCategory);
            await this.subCategoryRepository.SaveChangesAsync();

            return subCategory;
        }

        public async Task<SubCategory> CreateSubCategory(string subCategoryName, int categoryId)
        {
            SubCategory subCategory = new SubCategory
            {
                Name = subCategoryName,
                CategoryId = categoryId,
            };

            await this.subCategoryRepository.AddAsync(subCategory);
            await this.subCategoryRepository.SaveChangesAsync();

            return subCategory;
        }

        public async Task DeleteSubCategory(string subCategoryName)
        {
            SubCategory subCategory = await this.GetByName(subCategoryName);

            this.subCategoryRepository.Delete(subCategory);
        }

        public async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await this.subCategoryRepository
                        .All()
                        .ToListAsync();
        }

        public async Task<SubCategory> GetByName(string subCategoryName)
        {
            return await this.subCategoryRepository
                        .All()
                        .FirstOrDefaultAsync(c => c.Name == subCategoryName);
        }
    }
}
