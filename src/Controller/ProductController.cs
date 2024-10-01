using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjemploCatedra1.src.Interface;
using EjemploCatedra1.src.Dtos;
using Microsoft.AspNetCore.Mvc;
using EjemploCatedra1.src.Mappers;

namespace EjemploCatedra1.src.Controller

{
    
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateProductDto createProductDto)
        {
            bool exist = await _productRepository.ExistsByCode(createProductDto.Code);

            if(exist)
            {
                return Conflict("El codigo del producto ya existe");
            }
            else
            {
                var productModel = createProductDto.ToProductFromCreatedDto();
                await _productRepository.Post(productModel);
                return Created();
            }

        }

    }
}