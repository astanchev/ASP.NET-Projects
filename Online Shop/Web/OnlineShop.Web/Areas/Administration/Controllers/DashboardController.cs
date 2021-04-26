namespace OnlineShop.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Services.Data.Interfaces;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    using System.Threading.Tasks;

    public class DashboardController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public DashboardController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await this.categoryService.GetAll();

            var viewModel = new IndexViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }
    }
}
