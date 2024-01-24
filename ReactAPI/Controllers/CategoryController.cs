using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactAPI.Models;
using ReactAPI.Models;

namespace ReactAPI.Controllers
{
    [Route("api/[controller]")]
    //api/category
    [ApiController]
    public class CategoryController : ControllerBase
    {

        DataContext db = new DataContext();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Category> GetAll()
        {
            return db.Category.ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Category GetById(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id);
            return category;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                db.Category.Remove(category);
                db.SaveChanges();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Category category)
        {
            if (!String.IsNullOrEmpty(category.Title))
            {
                db.Category.Add(category);
                db.SaveChanges();
                return Ok("Basarili");
            }
            else
            {
                return Ok("Basarisiz");
            }
        }


        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put2(int id, Category category)
        {
            var findCategory = db.Category.FirstOrDefault(x => x.Id == id);
            if (findCategory != null)
            {
                findCategory.Title = category.Title;
                findCategory.IsStatus = category.IsStatus;
                db.SaveChanges();
                return Ok("Basarili");
            }
            else
            {
                return Ok("Kategori Bulunamadı");
            }
        }
    }
}
