using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseAPIController
    {

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCart(string id)
        {
           var cart = await cartService.GetCartAsync(id);

            return Ok(cart ?? new ShoppingCart { Id = id }); 
        }


        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            
            var updatedCart = await cartService.SetCartAsync(cart);

            if (updatedCart == null || string.IsNullOrEmpty(cart.Id))
            {
                return BadRequest("Invalid cart data.");
            }


            return Ok(updatedCart);
        }


        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCart(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Cart ID cannot be null or empty.");
            }

            var result = await cartService.DeleteCartAsync(id);

            if (!result)
            {
                return NotFound("Cart not found.");
            }
            return Ok(result);
        }
    }
}
