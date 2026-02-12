using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MiddlewareDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Please the request(Incoming)/response(Outgoing) with the same header" });
        }
    }
}


//[00 - 235389ecb537a0dc9eccb2b92af0f2c5 - 42ea09990f90f4de - 00] Incoming request: GET / api / Test
//[00 - 235389ecb537a0dc9eccb2b92af0f2c5 - 42ea09990f90f4de - 00] Outgoing response: 200
//[00 - 211f8a2b2dabfa0f9afecc235bc11e49 - 6c5cde530f61b12a - 00] Incoming request: GET / api / Test
//[00 - 211f8a2b2dabfa0f9afecc235bc11e49 - 6c5cde530f61b12a - 00] Outgoing response: 200