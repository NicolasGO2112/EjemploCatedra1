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
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Code = productModel.Code,
                Name = productModel.Name,
                Category = productModel.Category,
                Stock = productModel.Stock
            };
        }

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