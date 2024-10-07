using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.BLL.Services;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cafe_Delight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {


        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.cartService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.cartService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CartRequestDTO cartRequest)
        {
            var result = await this.cartService.Add(cartRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, CartRequestDTO v)
        {
            await this.cartService.Update(id, v);
            return Ok(v);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.cartService.Delete(id);
                if (result) return Ok("Deleted");
                return NotFound("Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


    }
}
