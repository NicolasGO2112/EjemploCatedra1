using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploCatedra1.src.Dtos;
using EjemploCatedra1.src.Models;

namespace EjemploCatedra1.src.Mappers
{
    public static class ProductMapper
    {
        public static Product ToProductFromCreatedDto(this CreateProductDto createdProductDto)
        {
            return new Product
            {
                Code = createdProductDto.Code,
                Name = createdProductDto.Name,
                Category = createdProductDto.Category,
                Stock = createdProductDto.Stock
            };
        }
    }
}