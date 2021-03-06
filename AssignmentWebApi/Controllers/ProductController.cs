using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssignmentWebApi.Entities;
using AssignmentWebApi.model;

namespace AssignmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByCategory(string subcategory)
        {
            if (subcategory == null)
            {
                var products = new List<ProductModel>();
                foreach (var item in await _context.Products.Include(x => x.SubCategory).ThenInclude(y => y.Category).ToArrayAsync())
                {
                    products.Add(new ProductModel(item.Id, item.Name, item.Description, item.Price, item.SubCategoryId, item.SubCategory.Category.Name, item.SubCategory.Name));
                }
                return Ok(products);
            }
            else
            {
                var products = new List<ProductModel>();
                foreach (var item in await _context.Products.Include(x => x.SubCategory).ThenInclude(y => y.Category).Where(x => x.SubCategory.Name == subcategory).ToArrayAsync())
                {
                    products.Add(new ProductModel(item.Id, item.Name, item.Description, item.Price, item.SubCategoryId, item.SubCategory.Category.Name, item.SubCategory.Name));
                }
                return Ok(products);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProduct(int id)
        {
            var product = await _context.Products.Include(x => x.SubCategory)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(new ProductModel(product.Id, product.Name, product.Description, product.Price, product.SubCategoryId, product.SubCategory.Category.Name, product.SubCategory.Name));
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductModel model)
        {
            if (!ModelState.IsValid || id != model.Id)
                return BadRequest();

            var productToUpdate = await _context.Products.FindAsync(id);
            if (productToUpdate == null)
            {
                return NotFound();

            }
            else
            {
                productToUpdate.Name = model.Name;
                productToUpdate.Description = model.Description;
                productToUpdate.Price = (decimal)model.Price;
                productToUpdate.SubCategoryId = model.SubCategoryId;

                _context.Entry(productToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }


        }

        [HttpPost]
        public async Task<ActionResult<ProductEntity>> CreateProduct(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                var subCategory = await _context.SubCategories.FindAsync(model.SubCategoryId);
                if (subCategory == null)
                {
                    return new BadRequestObjectResult(new ErrorMessage { StatusCode = 400, Error = "Invalid or no subcategory id provided." });
                }
                else
                {
                    var createProduct = new ProductEntity(model.Name, model.Description, model.Price, model.CategoryName, model.SubCategoryId);
                    _context.Products.Add(createProduct);
                    await _context.SaveChangesAsync();

                    return Ok(createProduct);
                }

            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            if (productToDelete == null)
            {
                return NotFound();

            }
            else
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();

                return NoContent();
            }


        }
    }
}
