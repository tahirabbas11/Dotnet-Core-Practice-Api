using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // In-memory product list
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Wireless Mouse", Price = 1500 },
            new Product { Id = 2, Name = "Keyboard", Price = 2500 },
            new Product { Id = 3, Name = "keyboard", Price = 2500 }
        };

        // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(
            [FromQuery] int? id,
            [FromQuery] string? name,
            [FromQuery] int? maxPrice,
            [FromQuery] int? minPrice)
        {
            var filteredProducts = Products.Where(p =>
                (!id.HasValue || p.Id == id) &&
                (string.IsNullOrEmpty(name) || p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) &&
                (!maxPrice.HasValue || p.Price <= maxPrice) &&
                (!minPrice.HasValue || p.Price >= minPrice)
            ).ToList();

            return Ok(filteredProducts);
        }

        // GET: api/product/1
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(new { error = "Product not found" });
            }

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            if (Products.Any(p => p.Id == product.Id))
            {
                return Conflict(new { error = "Product with this ID already exists." });
            }

            Products.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
    }
}
