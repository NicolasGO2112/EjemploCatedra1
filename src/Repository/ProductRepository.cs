using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploCatedra1.src.Data;
using EjemploCatedra1.src.Dtos;
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

        public async Task<Product?> Delete(int id)
        {
            var productModel = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(productModel == null)
            {
                throw new Exception("Product not found");
            }
            _dataContext.Products.Remove(productModel);
            await _dataContext.SaveChangesAsync();
            return productModel;
        }

        public async Task<bool> ExistsByCode(string code)
        {
            return await _dataContext.Products.AnyAsync(x => x.Code == code);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _dataContext.Products.FindAsync(id);
        }

        public async Task<Product> Post(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
            return product;
            
        }

        public async Task<Product?> Put(int id, UpdateProductDto updateProductDto)
        {
            var productModel = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                throw new Exception("Product not found");
            }
            productModel.Code = updateProductDto.Code;
            productModel.Name = updateProductDto.Name;
            productModel.Category = updateProductDto.Category;
            productModel.Stock = updateProductDto.Stock;
            await _dataContext.SaveChangesAsync();
            return productModel;

        }
    }
}