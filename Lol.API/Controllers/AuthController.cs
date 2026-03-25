using Lol.API.Models.DbMysqlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Lol.API.Models.DbMysqlModels.Login;

namespace Lol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ChampsContext _context = new ChampsContext();

        [HttpPost("/api/login")]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            var username = login.Username;
            var password = login.Password;
            var savedUserName = await _context.Logins.Select(x => x.Username).ToListAsync();
            var savedPassword = await _context.Logins.Select(x => x.Password).ToListAsync();
          

            if (savedUserName.Contains(username))
            {
                var ellenorzes = await _context.Logins.Where(x => x.Username == username).Select(x => x.Password).FirstOrDefaultAsync();
                
                if (ellenorzes == password)
                {
                    Authenticator.loggedin = true;
                    await _context.SaveChangesAsync();
                    return Ok();
                    
                }
                else
                {
                    return NotFound("Username or Password is not found");
                }
            }
            else
            {
                return NotFound("Username or Password is not found");
            }


        }


    }
}
