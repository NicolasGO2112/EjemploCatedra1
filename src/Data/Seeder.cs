using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploCatedra1.src.Models;

namespace EjemploCatedra1.src.Data
{
    public class Seeder
    {
         public static async Task Seed(DataContext context)
        {
            if (context.Products.Any())
                return;

            var categories = new string[] { "POLERAS", "PANTALONES", "SOMBREROS" };
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    Code = $"P{i}",
                    Name = $"Product {i}",
                    Category = categories[random.Next(0, categories.Length)],
                    Stock = random.Next(1, 100)
                };

                await context.Products.AddAsync(product);
            }

            await context.SaveChangesAsync();
        }
    }
}