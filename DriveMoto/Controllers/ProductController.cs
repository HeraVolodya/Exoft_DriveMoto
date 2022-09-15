using DriveMoto.DataBase;
using DriveMoto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Security;
using AutoMapper;
using DriveMoto.Models.DTOs;
using DriveMoto.Models.AddRequest;
using DriveMoto.Models.UpdateRequests;

namespace DriveMoto.Controllers
{
    [ApiController]
    [Route("/api/[controller]")] 

    public class ProductController : Controller
    {
        private readonly APIDbContext _dbProducts;
        private readonly IMapper _mapper;

        public ProductController(APIDbContext dbProducts, IMapper mapper)
        {
            _dbProducts = dbProducts;
            _mapper = mapper;
        }

         
        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await _dbProducts.Products.ToListAsync());
        
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)
        {
            try
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = addProductRequest.Name,
                    ImageURL = addProductRequest.ImageURL,
                    СodeProduct = addProductRequest.СodeProduct,
                    Сategory = addProductRequest.Сategory,
                    Price = addProductRequest.Price,
                    Discount = addProductRequest.Discount
                };
                await _dbProducts.Products.AddAsync(product);
                await _dbProducts.SaveChangesAsync();

                return Ok(_mapper.Map<ProductDTO>(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductRequest updateProductRequest)
        {
            try
            {
                var product = await _dbProducts.Products.FindAsync(id);
                if (product != null)
                {
                    product.Name = updateProductRequest.Name;
                    product.СodeProduct = updateProductRequest.СodeProduct;
                    product.Price = updateProductRequest.Price;
                    product.Discount = updateProductRequest.Discount;

                    await _dbProducts.SaveChangesAsync();

                    return Ok(_mapper.Map<ProductDTO>(product));

                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteЗкщвгсе([FromRoute] Guid id)
        {
            try
            {
                var product = await _dbProducts.Products.FindAsync(id);

                if (product != null)
                {
                    _dbProducts.Remove(product);
                    await _dbProducts.SaveChangesAsync();
                    return Ok(NoContent);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}
