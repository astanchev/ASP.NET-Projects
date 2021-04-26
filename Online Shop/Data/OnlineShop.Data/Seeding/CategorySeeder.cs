namespace OnlineShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using OnlineShop.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddRangeAsync(
                new List<Product>
                {
                    new Product
                    {
                        Name = "Clothes",
                        SubCategories = new List<SubCategory>
                        {
                            new SubCategory { Name = "Mens" },
                            new SubCategory { Name = "Womens" },
                            new SubCategory { Name = "Juniors" },
                            new SubCategory { Name = "Kids" },
                        },
                    },
                    new Product
                    {
                        Name = "Electronics",
                        SubCategories = new List<SubCategory>
                        {
                            new SubCategory { Name = "TV" },
                            new SubCategory { Name = "Audio" },
                            new SubCategory { Name = "PC" },
                            new SubCategory { Name = "Accessories" },
                        },
                    },
                    new Product
                    {
                        Name = "Home appliances",
                        SubCategories = new List<SubCategory>
                        {
                            new SubCategory { Name = "Washing machines" },
                            new SubCategory { Name = "Refigerators" },
                            new SubCategory { Name = "Cookers" },
                            new SubCategory { Name = "Dishwashers" },
                        },
                    },
                });
        }
    }
}
