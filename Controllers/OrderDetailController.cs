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
    public class OrderDetailController : ControllerBase
    {

        private readonly IOrderDetailService orderdetailService;

        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            this.orderdetailService = orderdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.orderdetailService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.orderdetailService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailRequestDTO orderdetailRequest)
        {
            var result = await this.orderdetailService.Add(orderdetailRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailRequestDTO v)
        {
            await this.orderdetailService.Update(id, v);
            return Ok(v);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.orderdetailService.Delete(id);
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
