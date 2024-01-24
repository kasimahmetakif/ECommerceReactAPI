using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        // GET:
        [HttpGet("{userId}")]
        public ActionResult<Cart> GetCart(int userId)
        {
            var cart = _context.Cart.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                return NotFound();
            }

            cart.Items = _context.CartItem.Where(ci => ci.Id == cart.Id).ToList();

            return cart;
        }

        // POST:
        [HttpPost]
        public ActionResult<Cart> CreateCart(Cart cart)
        {
            _context.Cart.Add(cart);
            _context.SaveChanges();

            return CreatedAtAction("GetCart", new { userId = cart.UserId }, cart);
        }

        // POST:
        [HttpPost("Item")]
        public ActionResult<CartItem> AddItemToCart(CartItem cartItem)
        {
            var cart = _context.Cart.FirstOrDefault(c => c.Id == cartItem.Id);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            _context.CartItem.Add(cartItem);
            _context.SaveChanges();

            return CreatedAtAction("GetCart", new { userId = cart.UserId }, cartItem);
        }

        // PUT: 
        [HttpPut("Item/{id}")]
        public IActionResult UpdateCartItem(int id, CartItem cartItem)
        {
            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            var existingItem = _context.CartItem.FirstOrDefault(ci => ci.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Quantity = cartItem.Quantity;
            existingItem.TotalPrice = cartItem.TotalPrice;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE
        [HttpDelete("Item/{id}")]
        public IActionResult RemoveItemFromCart(int id)
        {
            var cartItem = _context.CartItem.FirstOrDefault(ci => ci.Id == id);

            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItem.Remove(cartItem);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
