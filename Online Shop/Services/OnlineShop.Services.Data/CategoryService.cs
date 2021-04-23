namespace OnlineShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using OnlineShop.Data.Common.Repositories;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Data.Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> AddSubCategory(string categoryName, SubCategory subCategory)
        {
            Category category = await this.GetByName(categoryName);
            category.SubCategories.Add(subCategory);

            this.categoryRepository.Update(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public async Task<Category> ChangeCategoryName(string categoryOldName, string categoryNewName)
        {
            Category category = await this.GetByName(categoryOldName);
            category.Name = categoryNewName;

            this.categoryRepository.Update(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public async Task<Category> CreateCategory(string categoryName)
        {
            Category category = new Category { Name = categoryName };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public async Task<Category> CreateCategoryWithSubCategories(string categoryName, IEnumerable<SubCategory> subCategories)
        {
            Category category = new Category(categoryName, subCategories.ToList());

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(string categoryName)
        {
            Category category = await this.GetByName(categoryName);

            this.categoryRepository.Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await this.categoryRepository
                        .All()
                        .ToListAsync();
        }

        public async Task<Category> GetByName(string categoryName)
        {
            return await this.categoryRepository
                        .All()
                        .FirstOrDefaultAsync(c => c.Name == categoryName);
        }
    }
}
