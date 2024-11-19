using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HPlusSport.Web.Classes;

namespace HPlusSport.Web.Models
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Active Wear - Men" },
                new Category { Id = 2, Name = "Active Wear - Women" },
                new Category { Id = 3, Name = "Mineral Water" },
                new Category { Id = 4, Name = "Publications" },
                new Category { Id = 5, Name = "Supplements" }
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1, Category = categories.Single(c => c.Name == "Active Wear - Men"),
                    Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true
                },
                new Article
                {
                    Id = 2, Category = categories.Single(c => c.Name == "Active Wear - Men"), Name = "Polo Shirt",
                    Sku = "AWMPS", Price = 35, IsAvailable = true
                },
                new Article
                {
                    Id = 3, Category = categories.Single(c => c.Name == "Active Wear - Men"),
                    Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true
                },
                new Article
                {
                    Id = 4, Category = categories.Single(c => c.Name == "Active Wear - Men"), Name = "Slicker Jacket",
                    Sku = "AWMSJ", Price = 125, IsAvailable = true
                },
                new Article
                {
                    Id = 5, Category = categories.Single(c => c.Name == "Active Wear - Men"),
                    Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true
                },
                new Article
                {
                    Id = 6, Category = categories.Single(c => c.Name == "Active Wear - Men"),
                    Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true
                },
                new Article
                {
                    Id = 7, Category = categories.Single(c => c.Name == "Active Wear - Men"), Name = "V-Neck Pullover",
                    Sku = "AWMVNP", Price = 65, IsAvailable = true
                },
                new Article
                {
                    Id = 8, Category = categories.Single(c => c.Name == "Active Wear - Men"), Name = "V-Neck Sweater",
                    Sku = "AWMVNS", Price = 65, IsAvailable = true
                },
                new Article
                {
                    Id = 9, Category = categories.Single(c => c.Name == "Active Wear - Men"), Name = "V-Neck T-Shirt",
                    Sku = "AWMVNT", Price = 17, IsAvailable = true
                },
                new Article
                {
                    Id = 10, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99, IsAvailable = true
                },
                new Article
                {
                    Id = 11, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0, IsAvailable = false
                },
                new Article
                {
                    Id = 12, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68, IsAvailable = true
                },
                new Article
                {
                    Id = 13, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125, IsAvailable = true
                },
                new Article
                {
                    Id = 14, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55, IsAvailable = true
                },
                new Article
                {
                    Id = 15, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22, IsAvailable = true
                },
                new Article
                {
                    Id = 16, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95, IsAvailable = true
                },
                new Article
                {
                    Id = 17, Category = categories.Single(c => c.Name == "Active Wear - Women"),
                    Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Mineral Water"),
                    Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 19, Category = categories.Single(c => c.Name == "Mineral Water"),
                    Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 20, Category = categories.Single(c => c.Name == "Mineral Water"),
                    Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 21, Category = categories.Single(c => c.Name == "Mineral Water"), Name = "Peach Mineral Water",
                    Sku = "MWP", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 22, Category = categories.Single(c => c.Name == "Mineral Water"),
                    Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 23, Category = categories.Single(c => c.Name == "Mineral Water"),
                    Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Publications"),
                    Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M, IsAvailable = true
                },
                new Article
                {
                    Id = 18, Category = categories.Single(c => c.Name == "Supplements"),
                    Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M, IsAvailable = true
                }
            };
            articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();

            var users = new List<User>();
            var hashInformation = PasswordHelper.HashPassword("Adam's secret");
            users.Add(
                new User
                {
                    Id = 1,
                    Email = "adam@example.com",
                    Hash = hashInformation.Hash,
                    Salt = hashInformation.Salt
                });
            hashInformation = PasswordHelper.HashPassword("b@rb@r@");
            users.Add(
                new User
                {
                    Id = 2,
                    Email = "barbara@example.com",
                    Hash = hashInformation.Hash,
                    Salt = hashInformation.Salt
                });
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}