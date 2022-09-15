using DriveMoto.DataBase;
using DriveMoto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Security;
using AutoMapper;

namespace DriveMoto.Controllers
{
    [ApiController]
    [Route("/api/[controller]")] //слово api можна замінти, воно буде відображатися в пошуковій срічці браузерв
                                 // а замість слова [controller] буде підставлятися назва контролера, в даному випадку Produkts
    public class ProductController : Controller
    {
        private readonly APIDbContext _dbProducts;
        private readonly IMapper _mapper;

        public ProductController(APIDbContext dbProducts, IMapper mapper)
        {
            _dbProducts = dbProducts;
            _mapper = mapper;
        }

        //отримання вього списку товарив
        //отримання всього списку клієнтів  
        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await _dbProducts.Products.ToListAsync());
        //додавання нового продукту
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
        //редагування продукту
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
        //видалення продукту
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
