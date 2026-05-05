using System;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    

    public class ProductsController(IUnitOfWork unit) : BaseAPIController
    { 

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
            [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductSpecification(specParams);
            
        

            return await createPageResult(unit.Repository<Product>(), spec, specParams.PageIndex, specParams.PageSize);  
        }

        [HttpGet("{id:int}")] // api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await unit.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            unit.Repository<Product>().Add(product);

            if (await unit.Complete())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }

            return BadRequest("Failed to create product");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id || !await ProductExists(id)) 
                return BadRequest("Can not update this product");

            unit.Repository<Product>().Update(product);

            if (await unit.Complete())
            {
                return NoContent();
            }
            
            return BadRequest("Failed to update product");
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await unit.Repository<Product>().GetByIdAsync(id);

            if (product == null) return NotFound();

            unit.Repository<Product>().Remove(product);

            
            if (await unit.Complete())
            {
                return NoContent();
                
            }    


            return BadRequest("Failed to delete product");
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var spec = new BandListSpecification();
            return Ok(await unit.Repository<Product>().ListAsync(spec));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var spec = new TypeListSpecification();
            return Ok(await unit.Repository<Product>().ListAsync(spec));
        }

        private async Task<bool> ProductExists(int id)
        {
            return await unit.Repository<Product>().Exists(id);
            
        }







    }
