using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login([FromForm] string userName, [FromForm] string password)
        {
            if (userName != "admin" || password != "Admin123")
            {
                return BadRequest(new { error = "Invalid login credentials" });
            }

            var randomBase64 = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return Ok(new { message = "Login successful", token = randomBase64 });
        }
    }
}
