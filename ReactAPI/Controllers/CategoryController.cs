using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _context.Category.Where(c => c.IsStatus).ToList();
        }

        // GET: 
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id && c.IsStatus);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST:
        [HttpPost]
        [Authorize]
        public ActionResult<Category> PostCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        // PUT: 
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = _context.Category.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Title = category.Title;
            existingCategory.Description = category.Description;
            existingCategory.ImageSlug = category.ImageSlug;
            existingCategory.IsStatus = category.IsStatus;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: 
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
