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
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Put([FromRoute] int id , [FromBody] UpdateProductDto updateProductDto)
        { 
            var productModel = await _productRepository.Put(id, updateProductDto);
            if(productModel == null)
            {
                return NotFound();
            }
            return Ok(productModel.ToProductDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productDto = products.Select(p => p.ToProductDto());
            return Ok(productDto);
        
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }


        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var product = _productRepository.Delete(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


    }
}