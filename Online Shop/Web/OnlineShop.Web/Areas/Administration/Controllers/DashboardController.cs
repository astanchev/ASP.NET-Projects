namespace OnlineShop.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Services.Data.Interfaces;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {

        public DashboardController()
        {

        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel {  };
            return this.View(viewModel);
        }
    }
}
