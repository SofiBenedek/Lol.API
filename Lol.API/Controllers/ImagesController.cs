using Lol.API.Models.DbMysqlModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ChampsContext _context = new ChampsContext();

        [HttpGet("/api/images/filename")]
        public async Task<IActionResult> GetImagesByName([FromQuery] string filename)
        {
            var fname = await _context.Orders.Where(x => x.Images == filename).FirstOrDefaultAsync();

            if (fname == null)
            {
                return NotFound("Nincs adat");
            }
            return Ok(new { champs = fname });
        }



    }
}
