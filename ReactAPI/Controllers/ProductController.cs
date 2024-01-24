using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _context.Product.ToList();
        }

        // GET:
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST:
        [HttpPost]
        [Authorize]
        public ActionResult<Product> PostProduct(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // PUT: 
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Product.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return product;
        }
    }
}
