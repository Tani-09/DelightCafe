using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cafe_Delight.BLL.Services;
using Cafe_Delight.BLL.DTOs.Request;
using Microsoft.AspNetCore.Authorization;


namespace Cafe_Delight.Controllers
{





    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogInService LogInService;
        public LogInController(ILogInService LogInService)
        {
            this.LogInService = LogInService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        
        public async Task<IActionResult> LogIn(LogInRequestDTO LogInRequestDTO)
        {
            var result = await LogInService.IsValidUser(LogInRequestDTO);
            if (result is not null)
            {
                return Ok(result);
            }
            return Unauthorized(new { message = "Invalid Login!" });
        }
    }


}
