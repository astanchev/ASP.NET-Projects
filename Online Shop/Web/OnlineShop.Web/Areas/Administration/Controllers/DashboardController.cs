﻿namespace OnlineShop.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using OnlineShop.Services.Data.Interfaces;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

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

            var viewModel = new IndexCategoryViewModel
            {
                Categories = categories,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            if (categoryName.Length < 3 || categoryName.Length > 30)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            var category = await this.categoryService.CreateCategory(categoryName);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
