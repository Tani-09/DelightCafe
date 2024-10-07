using AutoMapper;
using Cafe_Delight.BLL.DTOs.Request;
using Cafe_Delight.BLL.DTOs.Response;
using Cafe_Delight.BLL.Services;
using Cafe_Delight.Controllers;
using Cafe_Delight.DAL.Entities;
using Cafe_Delight.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cafe_Delight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.addressService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.addressService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddressRequestDTO addressRequest)
        {
            var result = await this.addressService.Add(addressRequest);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressRequestDTO v)
        {
            await this.addressService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.addressService.Delete(id);
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


