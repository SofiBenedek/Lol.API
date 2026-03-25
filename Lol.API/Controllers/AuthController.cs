using Lol.API.Models.DbMysqlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ChampsContext _context = new ChampsContext();

        [HttpPost("/api/login")]
        public async Task<ActionResult> Login([FromBody] string username, int password)
        {

        }


    }
}
