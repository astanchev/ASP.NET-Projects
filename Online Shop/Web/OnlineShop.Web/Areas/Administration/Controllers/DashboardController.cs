namespace OnlineShop.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using OnlineShop.Services.Data.Interfaces;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;

        public DashboardController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await this.categoryService.GetAll();

            var viewModel = new IndexCategoryViewModel
            {
                Categories = categories.ToList(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            if (categoryName.Length < 3 || categoryName.Length > 30)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            var category = await this.categoryService.CreateCategory(categoryName);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(string subCategoryName, int categoryId)
        {
            if (subCategoryName.Length < 3 || subCategoryName.Length > 30)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            var subCategory = await this.subCategoryService.CreateSubCategory(subCategoryName, categoryId);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
