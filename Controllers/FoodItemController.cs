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
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemService fooditemService;

        public FoodItemController(IFoodItemService fooditemService)
        {
            this.fooditemService = fooditemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.fooditemService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.fooditemService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FoodItemRequestDTO fooditemRequest)
        {
            var result = await this.fooditemService.Add(fooditemRequest);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodItem(int id, FoodItemRequestDTO v)
        {
            await this.fooditemService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.fooditemService.Delete(id);
                if (result) return Ok("Deleted");
                return NotFound("Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("getbyCategoryId/{byCategoryId}")]
        public async Task<IActionResult> GetByCategoryId(int byCategoryId)
        {
            var result = await this.fooditemService.GetByCategoryId(byCategoryId);

            return Ok(result);

        }

    }
}
