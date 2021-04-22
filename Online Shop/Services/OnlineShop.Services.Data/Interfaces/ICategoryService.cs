namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public interface ICategoryService
    {
        Task<Category> GetByName(string categoryName);

        Task<IEnumerable<Category>> GetAll();

        Task<Category> CreateCategory(string categoryName);

        Task<Category> CreateCategoryWithSubCategories(string categoryName, IEnumerable<SubCategory> subCategories);

        Task<Category> ChangeCategoryName(string categoryName);

        Task<Category> AddSubCategory(string categoryName, SubCategory subCategory);

        Task<bool> DeleteCategory(string categoryName);
    }
}
