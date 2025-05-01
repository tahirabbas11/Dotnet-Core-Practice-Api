using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<User> GetUser([FromQuery] string name,[FromQuery] string email )
        {
            var user = new User
            {
                Name = name,
                Email = email
            };

            return Ok(user);
        }
    }
}
