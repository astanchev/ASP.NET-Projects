namespace OnlineShop.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineShop.Common;
    using OnlineShop.Services.Data.Interfaces;
    using OnlineShop.Web.ViewModels.Administration.Dashboard;

    [ApiController]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Route("api/[controller]")]
    public class CategoriesDataController : ControllerBase
    {
        private readonly ISubCategoryService subCategoryService;

        public CategoriesDataController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<SubCategoryOutputViewModel>> Get(int id)
        {
            var subCategories = await this.subCategoryService.GetAllByCategoryId(id);

            return subCategories;
        }
    }
}
