namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public interface ISubCategoryService
    {
        Task<SubCategory> GetByName(string subCategoryName);

        Task<IEnumerable<SubCategory>> GetAll();

        Task<SubCategory> CreateSubCategory(string subCategoryName);

        Task<SubCategory> ChangeSubCategoryName(string subCategoryName);

        Task<SubCategory> AddProduct(string subCategoryName, Product product);

        Task<bool> DeleteSubCategory(string subCategoryName);
    }
}
