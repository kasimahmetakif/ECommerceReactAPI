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
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;

        public BlogController(DataContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetBlogs()
        {
            return _context.Blog.Where(b => b.IsStatus).ToList();
        }

        // GET: 
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlogById(int id)
        {
            var blog = _context.Blog.FirstOrDefault(b => b.Id == id && b.IsStatus);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // POST:
        [HttpPost]
        [Authorize]
        public ActionResult<Blog> PostBlog(Blog blog)
        {
            _context.Blog.Add(blog);
            _context.SaveChanges();

            return CreatedAtAction("GetBlogById", new { id = blog.Id }, blog);
        }

        // PUT: 
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            var existingBlog = _context.Blog.FirstOrDefault(b => b.Id == id);
            if (existingBlog == null)
            {
                return NotFound();
            }

            existingBlog.Title = blog.Title;
            existingBlog.ShortDesc = blog.ShortDesc;
            existingBlog.LongDesc = blog.LongDesc;
            existingBlog.Image = blog.Image;
            existingBlog.Date = blog.Date;
            existingBlog.Img = blog.Img;
            existingBlog.IsStatus = blog.IsStatus;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE:
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.Blog.FirstOrDefault(b => b.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blog);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
