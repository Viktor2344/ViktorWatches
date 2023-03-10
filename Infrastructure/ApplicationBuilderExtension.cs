using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViktorWatches.Data;
using ViktorWatches.Domain;

namespace ViktorWatches.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataManufacturer = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedManufacturers(dataManufacturer);

            return app;

        }

        public static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0888888888";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "Admin123456");
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();

                }
            }
        }

        public static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName="Мъжки"},
                new Category {CategoryName="Дамски"},
                new Category {CategoryName="Детски"},
                new Category {CategoryName="Смарт Часовници"},
                new Category {CategoryName="Поръчкови часовници"},
                new Category {CategoryName="Аксеоари"},
            });
            dataCategory.SaveChanges();
        }

        public static void SeedManufacturers(ApplicationDbContext dataManufacturer)
        {
            if (dataManufacturer.Manufacturers.Any())
            {
                return;
            }

            dataManufacturer.Manufacturers.AddRange(new[]
            {
                new Manufacturer{ManufacturerName="Casio"},
                new Manufacturer{ManufacturerName="Citizen"},
                new Manufacturer{ManufacturerName="Rolex"},
                new Manufacturer{ManufacturerName="Omega"},
                new Manufacturer{ManufacturerName="Huawei"},
                new Manufacturer{ManufacturerName="Tag Hauer"},
                new Manufacturer{ManufacturerName="Guess"},
                new Manufacturer{ManufacturerName="Jacob & Co"},

            });
            dataManufacturer.SaveChanges();
        }
    }
}
