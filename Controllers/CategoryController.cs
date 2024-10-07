using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.Services;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cafe_Delight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]



        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.categoryService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequestDTO categoryRequest)
        {
            var result = await this.categoryService.Add(categoryRequest);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequestDTO v)
        {
            await this.categoryService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.categoryService.Delete(id);
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
