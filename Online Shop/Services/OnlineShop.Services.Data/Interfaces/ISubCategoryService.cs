namespace OnlineShop.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public interface ISubCategoryService
    {
        Task<SubCategory> GetByName(string subCategoryName);

        Task<IEnumerable<SubCategoryOutputViewModel>> GetAllByCategoryId(int categoryId);

        Task<SubCategory> CreateSubCategory(string subCategoryName, int categoryId);

        Task<SubCategory> ChangeSubCategoryName(string subCategoryOldName, string subCategoryNewName);

        Task<SubCategory> AddProduct(string subCategoryName, Product product);

        Task DeleteSubCategory(string subCategoryName);
    }
}
