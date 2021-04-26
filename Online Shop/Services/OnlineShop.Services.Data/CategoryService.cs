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
    using OnlineShop.Services.Mapping;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> AddSubCategory(string categoryName, SubCategory subCategory)
        {
            Category category = await this.categoryRepository
                                        .All()
                                        .FirstOrDefaultAsync(c =>
                                                        c.Name == categoryName);
            category.SubCategories.Add(subCategory);

            this.categoryRepository.Update(category);
            await this.categoryRepository.SaveChangesAsync();

            return category;
        }

        public async Task<Category> ChangeCategoryName(string categoryOldName, string categoryNewName)
        {
            Category category = await this.categoryRepository
                                        .All()
                                        .FirstOrDefaultAsync(c =>
                                                        c.Name == categoryOldName);
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
            Category category = await this.categoryRepository
                                        .All()
                                        .FirstOrDefaultAsync(c =>
                                                        c.Name == categoryName);

            this.categoryRepository.Delete(category);
        }

        public async Task<IEnumerable<CategoryOutputViewModel>> GetAll()
        {
            return await this.categoryRepository
                        .All()
                        .To<CategoryOutputViewModel>()
                        .ToListAsync();
        }

        public async Task<CategoryOutputViewModel> GetByName(string categoryName)
        {
            return await this.categoryRepository
                        .All()
                        .To<CategoryOutputViewModel>()
                        .FirstOrDefaultAsync(c => c.Name == categoryName);
        }
    }
}
