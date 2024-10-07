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
    public class CustomerController : ControllerBase
    {


        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.customerService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.customerService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestDTO customerRequest)
        {
            var result = await this.customerService.Add(customerRequest);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerRequestDTO v)
        {
            await this.customerService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.customerService.Delete(id);
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
