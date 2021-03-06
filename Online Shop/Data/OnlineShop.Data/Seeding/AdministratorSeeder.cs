namespace OnlineShop.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OnlineShop.Common;
    using OnlineShop.Data.Models;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager.Users.Any())
            {
                return;
            }

            var administrator = new ApplicationUser
            {
                UserName = configuration["Administrator:UserName"],
                Email = configuration["Administrator:Email"],
                EmailConfirmed = true,
            };

            var administratorPassword = configuration["Administrator:Password"];

            var result = await userManager.CreateAsync(administrator, administratorPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(administrator, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
