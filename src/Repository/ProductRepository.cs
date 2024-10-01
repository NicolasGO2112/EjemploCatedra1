using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploCatedra1.src.Data;
using EjemploCatedra1.src.Interface;
using EjemploCatedra1.src.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploCatedra1.src.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> ExistsByCode(string code)
        {
            return await _dataContext.Products.AnyAsync(x => x.Code == code);
        }

        public async Task<Product> Post(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
            
        }
    }
}