using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using EjemploCatedra1.src.Dtos;
using EjemploCatedra1.src.Models;

namespace EjemploCatedra1.src.Interface
{
    public interface IProductRepository
    {
        Task <bool> ExistsByCode(string code);
        Task <Product> Post(Product product);
        Task <List<Product>> GetAll();
        Task <Product?> GetById(int id);
        Task <Product?> Put(int id, UpdateProductDto updateProductDto);
        Task <Product?> Delete(int id);
    }
}