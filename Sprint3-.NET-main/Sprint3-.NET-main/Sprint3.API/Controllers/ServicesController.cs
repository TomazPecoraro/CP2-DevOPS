using Microsoft.AspNetCore.Mvc;
using Sprint3.API.Extensions;
using Sprint3.Service;
using System.Net;

namespace Sprint3.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ServicesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getValue")]
        public IActionResult GetValue(int value)
        {
            try
            {
                var currencyValue = value.ToCurrency(); // Certifique-se de que ToCurrency() é um método de extensão válido
                return Ok(currencyValue);
            }
            catch (Exception ex)
            {
                // Log exception and return internal server error
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
